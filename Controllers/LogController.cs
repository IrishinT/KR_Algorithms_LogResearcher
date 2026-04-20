// Controllers/LogController.cs
using Controllers.Algorithms;
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
        public Dictionary<DateTime, int> HourlyTraffic { get; private set; } = new Dictionary<DateTime, int>();
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
            // === ВРЕМЯ — универсально ===
            var timeStr = ExtractTimestamp(line);
            var timestamp = string.IsNullOrEmpty(timeStr)
                ? DateTime.MinValue
                : ParseTimestamp(timeStr);

            // === Остальное — как было, но с защитой ===
            var ipMatch = Regex.Match(line, @"^(\d{1,3}(?:\.\d{1,3}){3})");
            if (!ipMatch.Success) return null;
            var ip = ipMatch.Groups[1].Value;

            var requestMatch = Regex.Match(line, @"""(GET|POST|PUT|DELETE|HEAD|OPTIONS|PATCH)\s+([^\s""]+)");
            var method = requestMatch.Success ? requestMatch.Groups[1].Value : "-";
            var url = requestMatch.Success ? requestMatch.Groups[2].Value : "-";

            var statusMatch = Regex.Match(line, @"""\s+(\d{3})\s+(\d+|-)");
            var statusCode = statusMatch.Success ? int.Parse(statusMatch.Groups[1].Value) : 0;
            var size = statusMatch.Success && statusMatch.Groups[2].Value != "-"
                ? int.Parse(statusMatch.Groups[2].Value) : 0;

            return new LogEntry
            {
                IP = ip,
                Timestamp = timestamp,  // Теперь правильно
                Method = method,
                Url = url,
                StatusCode = statusCode,
                Size = size
            };
        }

        private LogEntry ParseCombinedLog(string line)
        {
            // Просто делегируем в Common — там теперь универсальный парсинг
            return ParseCommonLog(line);
        }

        private DateTime ParseTimestamp(string timestamp)
        {
            // Список форматов от наиболее частых к редким
            var formats = new[]
            {
                // Apache/Nginx стандарт
                "dd/MMM/yyyy:HH:mm:ss zzz",
                "dd/MMM/yyyy:HH:mm:ss",
                // ISO 8601
                "yyyy-MM-ddTHH:mm:sszzz",
                "yyyy-MM-ddTHH:mm:ss",
                "yyyy-MM-dd HH:mm:ss",
                // Другие варианты
                "dd.MM.yyyy HH:mm:ss",
                "MM/dd/yyyy HH:mm:ss",
                "yyyy/MM/dd HH:mm:ss",
                "dd-MMM-yyyy HH:mm:ss",
                "MMM dd, yyyy HH:mm:ss"
            };

            // Очищаем от лишних символов
            var clean = timestamp.Trim().Trim('[', ']', '"', '\'');

            foreach (var format in formats)
            {
                if (DateTime.TryParseExact(clean, format,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out var result))
                    return result;
            }

            // Fallback: TryParse с автоматическим определением
            if (DateTime.TryParse(clean, 
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.AssumeLocal, out var fallback))
                return fallback;

            return DateTime.MinValue; // Сигнал, что время не распарсилось
        }

        private string ExtractTimestamp(string line)
        {
            // 1. Пробуем найти в квадратных скобках [17/May/2015:10:05:47 +0000]
            var bracketMatch = Regex.Match(line, @"\[([^\]]+)\]");
            if (bracketMatch.Success)
                return bracketMatch.Groups[1].Value;

            // 2. ISO-формат: 2023-10-15T14:30:00Z или 2023-10-15 14:30:00
            var isoMatch = Regex.Match(line,
                @"(\d{4}[-/]\d{2}[-/]\d{2}[T\s]\d{2}:\d{2}:\d{2}(?:\.\d+)?(?:Z|[+-]\d{2}:?\d{2})?)");
            if (isoMatch.Success)
                return isoMatch.Groups[1].Value;

            // 3. Формат: 15/Oct/2023:14:30:00 (без скобок)
            var apacheMatch = Regex.Match(line,
                @"(\d{2}/[A-Za-z]{3}/\d{4}:\d{2}:\d{2}:\d{2}(?:\s*[+-]\d{4})?)");
            if (apacheMatch.Success)
                return apacheMatch.Groups[1].Value;

            // 4. Простой формат: 2023-10-15 14:30:00
            var simpleMatch = Regex.Match(line,
                @"(\d{4}-\d{2}-\d{2}\s+\d{2}:\d{2}:\d{2})");
            if (simpleMatch.Success)
                return simpleMatch.Groups[1].Value;

            // 5. European: 15.10.2023 14:30:00
            var euroMatch = Regex.Match(line,
                @"(\d{2}\.\d{2}\.\d{4}\s+\d{2}:\d{2}:\d{2})");
            if (euroMatch.Success)
                return euroMatch.Groups[1].Value;

            return string.Empty; // Не нашли
        }

        /// <summary>
        /// Основной метод анализа логов. 
        /// Группирует данные с помощью собственной хеш-таблицы и сортирует по частоте.
        /// </summary>
        public void CalculateStatistics()
        {
            if (_entries.Count == 0) return;

            // хеш-таблицы для группировки
            var ipHashTable = new CustomHashTable<string, List<LogEntry>>();
            var pageHashTable = new CustomHashTable<string, List<LogEntry>>();

            // Заполняем хеш-таблицы за один проход по логам
            foreach (var entry in _entries)
            {
                // Группировка по IP
                if (!ipHashTable.TryGetValue(entry.IP, out var ipLogList))
                {
                    ipLogList = new List<LogEntry>();
                    ipHashTable.AddOrUpdate(entry.IP, ipLogList);
                }
                ipLogList.Add(entry);

                // Группировка по страницам
                if (!pageHashTable.TryGetValue(entry.Url, out var pageLogList))
                {
                    pageLogList = new List<LogEntry>();
                    pageHashTable.AddOrUpdate(entry.Url, pageLogList);
                }
                pageLogList.Add(entry);
            }

            // Формируем статистику по IP адресам
            IPStats = new List<IPStatistics>();
            foreach (var kvp in ipHashTable.GetAll())
            {
                var logs = kvp.Value;
                DateTime first = logs[0].Timestamp;
                DateTime last = logs[0].Timestamp;

                // Ищем минимальное и максимальное время
                foreach (var log in logs)
                {
                    if (log.Timestamp < first) first = log.Timestamp;
                    if (log.Timestamp > last) last = log.Timestamp;
                }

                IPStats.Add(new IPStatistics
                {
                    IP = kvp.Key,
                    RequestCount = logs.Count,
                    FirstSeen = first,
                    LastSeen = last,
                    Percentage = (double)logs.Count / _entries.Count * 100,
                    SuspiciousThreshold = SuspiciousThreshold
                });
            }
            // Вызываем собственную быструю сортировку по частоте (убыванию)
            FrequencySorter.SortIPsByFrequencyDescending(IPStats);

            // Формируем статистику по Страницам
            PageStats = new List<PageStatistics>();
            foreach (var kvp in pageHashTable.GetAll())
            {
                var logs = kvp.Value;
                DateTime first = logs[0].Timestamp;
                DateTime last = logs[0].Timestamp;
                int errors = 0;

                foreach (var log in logs)
                {
                    if (log.Timestamp < first) first = log.Timestamp;
                    if (log.Timestamp > last) last = log.Timestamp;
                    if (log.StatusCode >= 400) errors++;
                }

                PageStats.Add(new PageStatistics
                {
                    Url = kvp.Key,
                    RequestCount = logs.Count,
                    FirstSeen = first,
                    LastSeen = last,
                    ErrorCount = errors,
                    Percentage = (double)logs.Count / _entries.Count * 100
                });
            }
            // Сортировка страниц
            FrequencySorter.SortPagesByFrequencyDescending(PageStats);

            // Ошибки (стандартный список)
            Errors = new List<LogEntry>();
            foreach (var entry in _entries)
            {
                if (entry.StatusCode >= 400)
                    Errors.Add(entry);
            }

            // Статистика для графиков (заменяем встроенный Dictionary на стандартный только для UI графика, 
            // так как график WinForms требует стандартный IDictionary/IEnumerable, но расчет делаем сами)
            HourlyTraffic = new Dictionary<DateTime, int>();
            StatusCodeStats = new Dictionary<int, int>();

            foreach (var entry in _entries)
            {
                if (entry.Timestamp != DateTime.MinValue)
                {
                    DateTime hour = new DateTime(entry.Timestamp.Year, entry.Timestamp.Month, entry.Timestamp.Day, entry.Timestamp.Hour, 0, 0);
                    if (HourlyTraffic.ContainsKey(hour))
                        HourlyTraffic[hour]++;
                    else
                        HourlyTraffic[hour] = 1;
                }

                if (entry.StatusCode > 0)
                {
                    if (StatusCodeStats.ContainsKey(entry.StatusCode))
                        StatusCodeStats[entry.StatusCode]++;
                    else
                        StatusCodeStats[entry.StatusCode] = 1;
                }
            }
        }

        /// <summary>
        /// Поиск среди IP-адресов с использованием собственного алгоритма КМП.
        /// </summary>
        public List<IPStatistics> SearchIPs(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return IPStats;

            var result = new List<IPStatistics>();
            foreach (var stat in IPStats)
            {
                if (KmpSearcher.Contains(stat.IP, query))
                    result.Add(stat);
            }
            return result;
        }

        /// <summary>
        /// Поиск среди страниц с использованием алгоритма КМП.
        /// </summary>
        public List<PageStatistics> SearchPages(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return PageStats;

            var result = new List<PageStatistics>();
            foreach (var stat in PageStats)
            {
                if (KmpSearcher.Contains(stat.Url, query))
                    result.Add(stat);
            }
            return result;
        }

        /// <summary>
        /// Поиск ошибок по URL или IP-адресу.
        /// </summary>
        public List<LogEntry> SearchErrors(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return Errors;

            var result = new List<LogEntry>();
            foreach (var error in Errors)
            {
                if (KmpSearcher.Contains(error.Url, query) || KmpSearcher.Contains(error.IP, query))
                    result.Add(error);
            }
            return result;
        }

        // Экспорт в CSV
        public void ExportToCSV(string filePath, ExportType type)
        {
            using var writer = new StreamWriter(filePath);

            var culture = System.Globalization.CultureInfo.InvariantCulture;

            switch (type)
            {
                case ExportType.IP:
                    writer.WriteLine("IP,Запросов,Процент,Первый,Последний,Статус");
                    foreach (var ip in IPStats)
                    {
                        var percent = ip.Percentage.ToString("F2", culture); // "33.33" вместо "33,33"
                        var status = ip.IsSuspicious ? "Подозр." : "Норма";
                        writer.WriteLine($"{ip.IP},{ip.RequestCount},{percent},{ip.FirstSeen:yyyy-MM-dd HH:mm:ss},{ip.LastSeen:yyyy-MM-dd HH:mm:ss},{status}");
                    }
                    break;

                case ExportType.Pages:
                    writer.WriteLine("URL,Запросов,Процент,Ошибок,Статус");
                    foreach (var page in PageStats)
                    {
                        var percent = page.Percentage.ToString("F2", culture);
                        var status = page.ErrorCount > 0 ? "С ошибками" : "OK";
                        // Экранируем URL если там есть запятые
                        var url = page.Url.Contains(",") ? $"\"{page.Url}\"" : page.Url;
                        writer.WriteLine($"{url},{page.RequestCount},{percent},{page.ErrorCount},{status}");
                    }
                    break;

                case ExportType.Errors:
                    writer.WriteLine("Время,URL,Код,IP");
                    foreach (var error in Errors)
                    {
                        var url = error.Url.Contains(",") ? $"\"{error.Url}\"" : error.Url;
                        writer.WriteLine($"{error.Timestamp:yyyy-MM-dd HH:mm:ss},{url},{error.StatusCode},{error.IP}");
                    }
                    break;
            }
        }
    }

    public enum LogFormat { Unknown, Apache, ApacheCombined, Nginx }
    public enum ExportType { IP, Pages, Errors }
}