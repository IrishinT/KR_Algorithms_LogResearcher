using Models;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class LogController
    {
        private List<LogEntry> _entries = new List<LogEntry>();

        // Основная статистика
        public int TotalRequests => _entries.Count;
        public int UniqueIPs => _entries.Select(x => x.IP).Distinct().Count();
        public int TotalErrors => _entries.Count(x => x.StatusCode >= 400);
        public int Errors404 => _entries.Count(x => x.StatusCode == 404);
        public int Errors500 => _entries.Count(x => x.StatusCode >= 500);

        // Данные для отображения
        public List<IPStatistics> IPStats { get; private set; } = new List<IPStatistics>();
        public List<PageStatistics> PageStats { get; private set; } = new List<PageStatistics>();
        public List<LogEntry> Errors { get; private set; } = new List<LogEntry>();

        // Данные для графика
        public Dictionary<string, int> HourlyTraffic { get; private set; } = new Dictionary<string, int>();
        public Dictionary<int, int> StatusCodeStats { get; private set; } = new Dictionary<int, int>();

        public void ParseFile(string filePath)
        {
            _entries.Clear();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var entry = ParseLine(line);
                if (entry != null)
                    _entries.Add(entry);
            }

            CalculateStatistics();
        }

        private LogEntry ParseLine(string line)
        {
            try
            {
                // Простейший парсер для Apache логов
                // 127.0.0.1 - - [10/Oct/2023:13:55:36 +0300] "GET /index.html HTTP/1.1" 200 2326
                var parts = line.Split(' ');
                if (parts.Length < 10) return null;

                var ip = parts[0];

                // Парсим время
                var timeStr = line.Split('[')[1].Split(']')[0];
                var timestamp = DateTime.ParseExact(
                    timeStr.Split(' ')[0],
                    "dd/MMM/yyyy:HH:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture);

                // Парсим запрос
                var request = line.Split('"')[1].Split(' ');
                var method = request[0];
                var url = request.Length > 1 ? request[1] : "-";

                // Парсим статус и размер
                var status = int.Parse(parts[^2]);
                var size = int.Parse(parts[^1]);

                return new LogEntry
                {
                    IP = ip,
                    Timestamp = timestamp,
                    Method = method,
                    Url = url,
                    StatusCode = status,
                    Size = size
                };
            }
            catch
            {
                return null; // Игнорируем кривые строки
            }
        }

        private void CalculateStatistics()
        {
            // Статистика по IP
            IPStats = _entries
                .GroupBy(x => x.IP)
                .Select(g => new IPStatistics
                {
                    IP = g.Key,
                    RequestCount = g.Count(),
                    FirstSeen = g.Min(x => x.Timestamp),
                    LastSeen = g.Max(x => x.Timestamp),
                    Percentage = (double)g.Count() / _entries.Count * 100
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

            // Почасовая статистика для графика
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
                .Where(x => x.IP.Contains(query))
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
                           x.IP.Contains(query))
                .ToList();
        }
    }
}