using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Tests
{
    public class LogControllerTests : IDisposable
    {
        private readonly List<string> _tempFiles = new();

        // Вспомогательный метод для создания временного лог-файла
        private string CreateTempLogFile(params string[] lines)
        {
            string path = Path.GetTempFileName();
            File.WriteAllLines(path, lines);
            _tempFiles.Add(path);
            return path;
        }

        // Очистка временных файлов после каждого теста
        public void Dispose()
        {
            foreach (var file in _tempFiles)
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
        }

        [Fact]
        public void ParseFile_ShouldCorrectlyParseValidLogsAndCalculateBasicStats()
        {
            // Arrange
            var controller = new LogController();
            var logLines = new[]
            {
                "192.168.1.1 - - [17/May/2015:10:05:00 +0000] \"GET /index.html HTTP/1.1\" 200 1024",
                "192.168.1.2 - - [17/May/2015:10:05:01 +0000] \"POST /api/login HTTP/1.1\" 404 500",
                "192.168.1.1 - - [17/May/2015:10:05:02 +0000] \"GET /about HTTP/1.1\" 500 0"
            };
            string filePath = CreateTempLogFile(logLines);

            // Act
            controller.ParseFile(filePath);

            // Assert
            Assert.Equal(3, controller.TotalRequests);
            Assert.Equal(2, controller.UniqueIPs); // 192.168.1.1 и 192.168.1.2
            Assert.Equal(2, controller.TotalErrors); // 404 и 500
            Assert.Equal(1, controller.Errors404);
            Assert.Equal(1, controller.Errors500);
        }

        [Fact]
        public void ParseFile_ShouldHandleInvalidAndPartiallyValidLines()
        {
            // Arrange
            var controller = new LogController();
            var logLines = new[]
            {
                "192.168.1.1 - - [17/May/2015:10:05:00 +0000] \"GET /index.html HTTP/1.1\" 200 1024", // Идеальная строка
                "This is some random garbage text that is not a log entry",                           // Полностью мусор (будет проигнорирована)
                "127.0.0.1 completely malformed rest of the line"                                     // Есть IP, но дальше мусор
            };
            string filePath = CreateTempLogFile(logLines);

            // Act
            controller.ParseFile(filePath);

            // Assert
            // Ожидаем 2 записи: первая идеальная, и третья (парсится частично, так как начинается с IP)
            Assert.Equal(2, controller.TotalRequests);

            // Убеждаемся, что частично сломанная строка распарсилась с дефолтными значениями
            var partialEntryIP = controller.IPStats.FirstOrDefault(x => x.IP == "127.0.0.1");
            Assert.NotNull(partialEntryIP);

            // Ошибки с кодом 0 не считаются HTTP ошибками (400+)
            Assert.Equal(0, controller.TotalErrors);
        }

        [Fact]
        public void CalculateStatistics_ShouldCorrectlyGroupDataByIPAndPage()
        {
            // Arrange
            var controller = new LogController();
            var logLines = new[]
            {
                "10.0.0.1 - - [01/Jan/2024:10:00:00 +0000] \"GET /home HTTP/1.1\" 200 100",
                "10.0.0.1 - - [01/Jan/2024:10:01:00 +0000] \"GET /home HTTP/1.1\" 200 100",
                "10.0.0.2 - - [01/Jan/2024:10:02:00 +0000] \"GET /contact HTTP/1.1\" 404 50"
            };
            string filePath = CreateTempLogFile(logLines);

            // Act
            controller.ParseFile(filePath);

            // Assert - IP Stats
            var ipStats = controller.IPStats;
            Assert.Equal(2, ipStats.Count);

            var ip1 = ipStats.First(x => x.IP == "10.0.0.1");
            Assert.Equal(2, ip1.RequestCount);

            // ИСПРАВЛЕНИЕ: 2 запроса из 3 это 66.666...%. 
            // Используем проверку диапазона (между 66.6 и 66.7), чтобы избежать проблем с плавающей точкой
            Assert.InRange(ip1.Percentage, 66.6, 66.7);

            // Assert - Page Stats
            var pageStats = controller.PageStats;
            Assert.Equal(2, pageStats.Count);

            var pageHome = pageStats.First(x => x.Url == "/home");
            Assert.Equal(2, pageHome.RequestCount);
            Assert.Equal(0, pageHome.ErrorCount);

            var pageContact = pageStats.First(x => x.Url == "/contact");
            Assert.Equal(1, pageContact.ErrorCount);
        }

        [Fact]
        public void SuspiciousThreshold_ShouldIdentifySuspiciousIPsCorrectly()
        {
            // Arrange
            var controller = new LogController();
            controller.SuspiciousThreshold = 2; // Ставим порог 2 для теста

            var logLines = new[]
            {
                "1.1.1.1 - - [01/Jan/2024:10:00:00 +0000] \"GET / HTTP/1.1\" 200 100",
                "1.1.1.1 - - [01/Jan/2024:10:01:00 +0000] \"GET / HTTP/1.1\" 200 100",
                "1.1.1.1 - - [01/Jan/2024:10:02:00 +0000] \"GET / HTTP/1.1\" 200 100", // 3 запроса (подозрительный)
                "2.2.2.2 - - [01/Jan/2024:10:03:00 +0000] \"GET / HTTP/1.1\" 200 100"  // 1 запрос (норма)
            };
            string filePath = CreateTempLogFile(logLines);

            // Act
            controller.ParseFile(filePath);

            // Assert
            Assert.Equal(1, controller.SuspiciousIPs);
            Assert.True(controller.IPStats.First(x => x.IP == "1.1.1.1").IsSuspicious);
            Assert.False(controller.IPStats.First(x => x.IP == "2.2.2.2").IsSuspicious);
        }

        [Fact]
        public void SearchFunctions_ShouldFilterResultsCorrectly()
        {
            // Arrange
            var controller = new LogController();
            var logLines = new[]
            {
                "192.168.0.100 - - [01/Jan/2024:10:00:00 +0000] \"GET /dashboard HTTP/1.1\" 200 100",
                "10.0.0.5 - - [01/Jan/2024:10:01:00 +0000] \"GET /admin HTTP/1.1\" 403 50",
                "172.16.0.1 - - [01/Jan/2024:10:02:00 +0000] \"POST /login HTTP/1.1\" 500 50"
            };
            controller.ParseFile(CreateTempLogFile(logLines));

            // Act & Assert - IP Search
            var searchIpResult = controller.SearchIPs("192");
            Assert.Single(searchIpResult);
            Assert.Equal("192.168.0.100", searchIpResult.First().IP);

            // Act & Assert - Page Search
            var searchPageResult = controller.SearchPages("admin");
            Assert.Single(searchPageResult);
            Assert.Equal("/admin", searchPageResult.First().Url);

            // Act & Assert - Error Search
            var searchErrorResult = controller.SearchErrors("172");
            Assert.Single(searchErrorResult);
            Assert.Equal(500, searchErrorResult.First().StatusCode);
        }

        [Fact]
        public void ExportToCSV_ShouldCreateFileWithData()
        {
            // Arrange
            var controller = new LogController();
            var logLines = new[]
            {
                "192.168.1.1 - - [01/Jan/2024:10:00:00 +0000] \"GET /home HTTP/1.1\" 200 100",
            };
            controller.ParseFile(CreateTempLogFile(logLines));

            string exportFilePath = Path.GetTempFileName();
            _tempFiles.Add(exportFilePath);

            // Act
            controller.ExportToCSV(exportFilePath, ExportType.IP);

            // Assert
            Assert.True(File.Exists(exportFilePath));
            var exportedLines = File.ReadAllLines(exportFilePath);

            Assert.Equal(2, exportedLines.Length); // 1 Заголовок + 1 Строка с данными
            Assert.Contains("IP,Запросов,Процент,Первый,Последний,Статус", exportedLines[0]);
            Assert.Contains("192.168.1.1,1,100.00", exportedLines[1]);
        }
    }
}