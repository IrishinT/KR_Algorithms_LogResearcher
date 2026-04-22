using Controllers;
using Models;
using System.Diagnostics;

namespace Controllers
{

    /// <summary>
    /// Основной контроллер для обработки, анализа и экспорта данных журналов доступа веб-сервера.
    /// Отвечает за потоковый парсинг строк, агрегацию метрик, выполнение строкового поиска 
    /// и формирование отчетов для пользовательского интерфейса.
    /// </summary>
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

        public TimeSpan HashTableTime { get; private set; }
        public TimeSpan SortingPageTime { get; private set; }
        public TimeSpan SortingIPTime { get; private set; }
        public TimeSpan KmpSearchTime { get; private set; }
        public TimeSpan StringParserTime { get; private set; }

        // Данные для отображения
        public List<IPStatistics> IPStats { get; private set; } = new List<IPStatistics>();
        public List<PageStatistics> PageStats { get; private set; } = new List<PageStatistics>();
        public List<LogEntry> Errors { get; private set; } = new List<LogEntry>();

        // Данные для графика
        public Dictionary<DateTime, int> HourlyTraffic { get; private set; } = new Dictionary<DateTime, int>();
        public Dictionary<int, int> StatusCodeStats { get; private set; } = new Dictionary<int, int>();

        // Событие для прогресс-бара
        public event Action<int, int> OnProgress;

        /// <summary>
        /// Выполняет потоковое чтение файла, определяет его формат и последовательно парсит каждую строку.
        /// </summary>
        /// <param name="filePath">Полный путь к файлу журнала.</param>
        public void ParseFile(string filePath)
        {
            _entries.Clear();
            _currentFormat = LogFormat.Unknown;

            var lines = File.ReadLines(filePath);
            int totalLines = 0;
            int processedLines = 0;

            var parserSw = new Stopwatch();

            // Определяем формат по первым 100 строкам
            foreach (var line in lines.Take(100))
            {
                parserSw.Start();
                var format = DetectFormat(line);
                parserSw.Stop();

                if (format != LogFormat.Unknown)
                {
                    _currentFormat = format;
                    break;
                }
            }

            if (_currentFormat == LogFormat.Unknown)
                _currentFormat = LogFormat.Apache;

            // Парсим весь файл потоково
            lines = File.ReadLines(filePath);
            foreach (var line in lines)
            {
                totalLines++;

                parserSw.Start();
                var entry = ParseLine(line);
                parserSw.Stop();

                if (entry != null) _entries.Add(entry);

                if (totalLines % 1000 == 0)
                {
                    processedLines += 1000;
                    OnProgress?.Invoke(processedLines, totalLines);
                }
            }

            StringParserTime = parserSw.Elapsed;

            OnProgress?.Invoke(totalLines, totalLines);
            CalculateStatistics();
        }

        private LogEntry ParseLine(string line)
        {
            try
            {
               return ParseCommonLog(line);
            }
            catch { return null; }
        }

        /// <summary>
        /// Эвристическое определение формата по количеству кавычек и наличию маркера [date].
        /// </summary>
        private LogFormat DetectFormat(string line)
        {
            int quoteCount = CustomStringParser.CountChar(line, '"');
            if (quoteCount >= 6) return LogFormat.Nginx;
            if (quoteCount >= 4) return LogFormat.ApacheCombined;
            if (quoteCount >= 2 && CustomStringParser.IndexOf(line, '[') >= 0) return LogFormat.Apache;
            return LogFormat.Unknown;
        }

        /// <summary>
        /// Извлекает поля из строки стандартного формата Apache: IP, время, метод, URL, код ответа, размер.
        /// </summary>
        private LogEntry ParseCommonLog(string line)
        {
            // 1. ВРЕМЯ: извлечение содержимого квадратных скобок
            int timeEnd = -1;
            string timeStr = CustomStringParser.ExtractBetween(line, '[', ']', out timeEnd);
            var timestamp = string.IsNullOrEmpty(timeStr) ? DateTime.MinValue : ParseTimestamp(timeStr);

            // 2. IP: поиск до первого пробела + валидация
            int ipEnd = CustomStringParser.IndexOf(line, ' ');
            if (ipEnd <= 0 || !CustomStringParser.IsValidIPv4(line.Substring(0, ipEnd))) return null;
            string ip = line.Substring(0, ipEnd);

            // 3. REQUEST: поиск между первыми кавычками после IP
            int reqEnd = -1;
            string request = CustomStringParser.ExtractQuoted(line, out reqEnd, ipEnd);
            string method = "-", url = "-";

            if (!string.IsNullOrEmpty(request))
            {
                int spaceInReq = CustomStringParser.IndexOf(request, ' ');
                if (spaceInReq > 0)
                {
                    method = request.Substring(0, spaceInReq).ToUpper();
                    int urlEnd = CustomStringParser.IndexOf(request, ' ', spaceInReq + 1);
                    url = urlEnd > 0 ? request.Substring(spaceInReq + 1, urlEnd - spaceInReq - 1) : request.Substring(spaceInReq + 1);
                }
            }

            // 4. STATUS & SIZE: парсинг целых чисел сразу после закрывающей кавычки
            int statusStart = reqEnd + 1;
            while (statusStart < line.Length && char.IsWhiteSpace(line[statusStart])) statusStart++;

            int statusEnd = statusStart;
            while (statusEnd < line.Length && char.IsDigit(line[statusEnd])) statusEnd++;
            int statusCode = 0;
            if (statusEnd > statusStart) int.TryParse(line.Substring(statusStart, statusEnd - statusStart), out statusCode);

            int sizeStart = statusEnd;
            while (sizeStart < line.Length && char.IsWhiteSpace(line[sizeStart])) sizeStart++;
            int sizeEnd = sizeStart;
            while (sizeEnd < line.Length && (char.IsDigit(line[sizeEnd]) || line[sizeEnd] == '-')) sizeEnd++;
            int size = 0;
            if (sizeEnd > sizeStart && line[sizeStart] != '-') int.TryParse(line.Substring(sizeStart, sizeEnd - sizeStart), out size);

            return new LogEntry
            {
                IP = ip,
                Timestamp = timestamp,
                Method = method,
                Url = url,
                StatusCode = statusCode,
                Size = size
            };
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

            var swHash = Stopwatch.StartNew();

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

            swHash.Stop();
            HashTableTime = swHash.Elapsed;

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

            var swIPSort = Stopwatch.StartNew();
            // Вызываем собственную быструю сортировку по частоте (убыванию)
            FrequencySorter.SortIPsByFrequencyDescending(IPStats);
            swIPSort.Stop();
            SortingIPTime = swIPSort.Elapsed;

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
            var swPageSort = Stopwatch.StartNew();
            FrequencySorter.SortPagesByFrequencyDescending(PageStats);
            swPageSort.Stop();
            SortingPageTime = swPageSort.Elapsed;

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

            var sw = new Stopwatch();
            sw.Start();
            foreach (var stat in IPStats)
            {
                if (KmpSearcher.Contains(stat.IP, query))
                    result.Add(stat);
            }
            sw.Stop();
            KmpSearchTime = sw.Elapsed;

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
            var sw = new Stopwatch();
            sw.Start();
            foreach (var stat in PageStats)
            {
                if (KmpSearcher.Contains(stat.Url, query))
                    result.Add(stat);
            }
            sw.Stop();
            KmpSearchTime = sw.Elapsed;

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

            var sw = new Stopwatch();
            sw.Start();
            foreach (var error in Errors)
            {
                if (KmpSearcher.Contains(error.Url, query) || KmpSearcher.Contains(error.IP, query))
                    result.Add(error);
            }
            sw.Stop();
            KmpSearchTime = sw.Elapsed;

            return result;
        }

    }

    public enum LogFormat { Unknown, Apache, ApacheCombined, Nginx }
    public enum ExportType { IP, Pages, Errors }
}