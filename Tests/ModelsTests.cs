using Models;
using Xunit;

namespace Tests
{
    public class ModelsTests
    {
        [Theory]
        [InlineData(100, 100, false)] // Запросов равно порогу -> не подозрительный
        [InlineData(99, 100, false)]  // Запросов меньше порога -> не подозрительный
        [InlineData(101, 100, true)]  // Запросов больше порога -> подозрительный
        [InlineData(500, 50, true)]   // Запросов сильно больше порога
        public void IPStatistics_IsSuspicious_ShouldReturnCorrectValue(int requestCount, int threshold, bool expectedIsSuspicious)
        {
            // Arrange
            var ipStats = new IPStatistics
            {
                IP = "192.168.1.1",
                RequestCount = requestCount,
                SuspiciousThreshold = threshold
            };

            // Act
            bool result = ipStats.IsSuspicious;

            // Assert
            Assert.Equal(expectedIsSuspicious, result);
        }
    }
}