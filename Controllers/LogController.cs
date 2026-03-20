// Controllers/LogController.cs
using Models;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class LogController
    {
        private List<LogEntry> _entries = new List<LogEntry>();
        private LogFormat _currentFormat = LogFormat.Unknown;

        // Порог подозрительной активности (из UI)
        public int SuspiciousThreshold { get; set; } = 100;

        // Основная статистика
        public int TotalRequests => _entries.Count;
        public int UniqueIPs => _entries.Select(x => x.IP).Distinct().Count();
        public int TotalErrors => _entries.Count(x => x.StatusCode >= 400);
        public int Errors404 => _entries.Count(x => x.StatusCode == 404);
        public int Errors500 => _entries.Count(x => x.StatusCode >= 500);
        public int SuspiciousIPs => IPStats.Count(x => x.RequestCount > SuspiciousThreshold);

        // Данные для отображения
        public List<IPStatistics> IPStats { get; private set; } = new List<IPStatistics>();
        public List<PageStatistics> PageStats { get; private set; } = new List<PageStatistics>();
        public List<LogEntry> Errors { get; private set; } = new List<LogEntry>();

        // Данные для графика
        public Dictionary<string, int> HourlyTraffic { get; private set; } = new Dictionary<string, int>();
        public Dictionary<int, int> StatusCodeStats { get; private set; } = new Dictionary<int, int>();

        // Событие для прогресс-бара
        public event Action<int, int> OnProgress;

        public void ParseFile(string filePath)
        {
            _entries.Clear();
            _currentFormat = LogFormat.Unknown;

            var lines = File.ReadLines(filePath); // Потоковое чтение для больших файлов
            int totalLines = 0;
            int processedLines = 0;

            // Сначала определяем формат
            foreach (var line in lines.Take(100))
            {
                var format = DetectFormat(line);
                if (format != LogFormat.Unknown)
                {
                    _currentFormat = format;
                    break;
                }
            }

            if (_currentFormat == LogFormat.Unknown)
                _currentFormat = LogFormat.Apache; // По умолчанию

            // Парсим весь файл
            lines = File.ReadLines(filePath);
            foreach (var line in lines)
            {
                totalLines++;
                var entry = ParseLine(line);
                if (entry != null)
                    _entries.Add(entry);

                // Обновляем прогресс каждые 1000 строк
                if (totalLines % 1000 == 0)
                {
                    processedLines += 1000;
                    OnProgress?.Invoke(processedLines, totalLines);
                }
            }

            OnProgress?.Invoke(totalLines, totalLines);
            CalculateStatistics();
        }

        private LogFormat DetectFormat(string line)
        {
            // Nginx: IP - - [date] "METHOD URL PROTO" status size "referer" "user-agent"
            if (Regex.IsMatch(line, @""".*""\s+"".*""\s+"".*""$"))
                return LogFormat.Nginx;

            // Apache Combined: похож на Nginx
            if (Regex.IsMatch(line, @""".*""\s+"".*""$"))
                return LogFormat.ApacheCombined;

            // Apache Common: IP - - [date] "METHOD URL PROTO" status size
            if (Regex.IsMatch(line, @"^\d+\.\d+\.\d+\.\d+\s+-\s+-\s+\["))
                return LogFormat.Apache;

            return LogFormat.Unknown;
        }

        private LogEntry ParseLine(string line)
        {
            try
            {
                switch (_currentFormat)
                {
                    case LogFormat.Nginx:
                    case LogFormat.ApacheCombined:
                        return ParseCombinedLog(line);
                    case LogFormat.Apache:
                    default:
                        return ParseCommonLog(line);
                }
            }
            catch
            {
                return null;
            }
        }

        private LogEntry ParseCommonLog(string line)
        {
            // 127.0.0.1 - - [10/Oct/2023:13:55:36 +0300] "GET /index.html HTTP/1.1" 200 2326
            var match = Regex.Match(line,
                @"^(\S+)\s+\S+\s+\S+\s+\[([^\]]+)\]\s+""(\S+)\s+(\S+)\s+[^""]*""\s+(\d+)\s+(\d+|-)");

            if (!match.Success) return null;

            return new LogEntry
            {
                IP = match.Groups[1].Value,
                Timestamp = ParseTimestamp(match.Groups[2].Value),
                Method = match.Groups[3].Value,
                Url = match.Groups[4].Value,
                StatusCode = int.Parse(match.Groups[5].Value),
                Size = match.Groups[6].Value == "-" ? 0 : int.Parse(match.Groups[6].Value)
            };
        }

        private LogEntry ParseCombinedLog(string line)
        {
            // Nginx/Apache Combined с referer и user-agent
            var match = Regex.Match(line,
                @"^(\S+)\s+\S+\s+\S+\s+\[([^\]]+)\]\s+""(\S+)\s+(\S+)\s+[^""]*""\s+(\d+)\s+(\d+|-)\s+""[^""]*""\s+""[^""]*""");

            if (!match.Success)
                return ParseCommonLog(line); // Пробуем как common

            return new LogEntry
            {
                IP = match.Groups[1].Value,
                Timestamp = ParseTimestamp(match.Groups[2].Value),
                Method = match.Groups[3].Value,
                Url = match.Groups[4].Value,
                StatusCode = int.Parse(match.Groups[5].Value),
                Size = match.Groups[6].Value == "-" ? 0 : int.Parse(match.Groups[6].Value)
            };
        }

        private DateTime ParseTimestamp(string timestamp)
        {
            // 10/Oct/2023:13:55:36 +0300
            var formats = new[]
            {
                "dd/MMM/yyyy:HH:mm:ss zzz",
                "dd/MMM/yyyy:HH:mm:ss",
                "yyyy-MM-dd HH:mm:ss",
                "dd/MMM/yyyy HH:mm:ss"
            };

            foreach (var format in formats)
            {
                if (DateTime.TryParseExact(timestamp, format,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out var result))
                    return result;
            }

            return DateTime.Now;
        }

        public void CalculateStatistics()
        {
            if (_entries.Count == 0) return;

            // Статистика по IP
            IPStats = _entries
                .GroupBy(x => x.IP)
                .Select(g => new IPStatistics
                {
                    IP = g.Key,
                    RequestCount = g.Count(),
                    FirstSeen = g.Min(x => x.Timestamp),
                    LastSeen = g.Max(x => x.Timestamp),
                    Percentage = (double)g.Count() / _entries.Count * 100,
                    SuspiciousThreshold = SuspiciousThreshold
                })
                .OrderByDescending(x => x.RequestCount)
                .ToList();

            // Статистика по страницам
            PageStats = _entries
                .GroupBy(x => x.Url)
                .Select(g => new PageStatistics
                {
                    Url = g.Key,
                    RequestCount = g.Count(),
                    FirstSeen = g.Min(x => x.Timestamp),
                    LastSeen = g.Max(x => x.Timestamp),
                    ErrorCount = g.Count(x => x.StatusCode >= 400),
                    Percentage = (double)g.Count() / _entries.Count * 100
                })
                .OrderByDescending(x => x.RequestCount)
                .ToList();

            // Ошибки
            Errors = _entries
                .Where(x => x.StatusCode >= 400)
                .OrderByDescending(x => x.Timestamp)
                .ToList();

            // Почасовая статистика
            HourlyTraffic = _entries
                .GroupBy(x => x.Timestamp.ToString("HH:00"))
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Count());

            // Статистика по кодам ответа
            StatusCodeStats = _entries
                .GroupBy(x => x.StatusCode)
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        // Поиск
        public List<IPStatistics> SearchIPs(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return IPStats;
            return IPStats
                .Where(x => x.IP.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<PageStatistics> SearchPages(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return PageStats;
            return PageStats
                .Where(x => x.Url.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<LogEntry> SearchErrors(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return Errors;
            return Errors
                .Where(x => x.Url.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                           x.IP.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Экспорт в CSV
        public void ExportToCSV(string filePath, ExportType type)
        {
            using var writer = new StreamWriter(filePath);

            switch (type)
            {
                case ExportType.IP:
                    writer.WriteLine("IP,Запросов,Процент,Первый,Последний,Статус");
                    foreach (var ip in IPStats)
                        writer.WriteLine($"{ip.IP},{ip.RequestCount},{ip.Percentage:F2},{ip.FirstSeen},{ip.LastSeen},{(ip.IsSuspicious ? "Подозр." : "Норма")}");
                    break;
                case ExportType.Pages:
                    writer.WriteLine("URL,Запросов,Процент,Ошибок,Статус");
                    foreach (var page in PageStats)
                        writer.WriteLine($"{page.Url},{page.RequestCount},{page.Percentage:F2},{page.ErrorCount},{(page.ErrorCount > 0 ? "С ошибками" : "OK")}");
                    break;
                case ExportType.Errors:
                    writer.WriteLine("Время,URL,Код,IP");
                    foreach (var error in Errors)
                        writer.WriteLine($"{error.Timestamp},{error.Url},{error.StatusCode},{error.IP}");
                    break;
            }
        }
    }

    public enum LogFormat { Unknown, Apache, ApacheCombined, Nginx }
    public enum ExportType { IP, Pages, Errors }
}