using Controllers;
using Xunit;

namespace Tests
{
    public class KmpSearcherTests
    {
        [Theory]
        [InlineData("Hello World", "World", true)]
        [InlineData("Log analysis is cool", "log", true)] // Проверка регистронезависимости
        [InlineData("192.168.1.1", "168", true)]
        [InlineData("192.168.1.1", "255", false)]
        [InlineData("/api/v1/users", "users", true)]
        [InlineData("abc", "abcd", false)] // Паттерн длиннее текста
        [InlineData("aaaaa", "aa", true)]  // Перекрывающиеся вхождения
        public void Contains_ShouldReturnCorrectResult(string text, string pattern, bool expected)
        {
            // Act
            bool result = KmpSearcher.Contains(text, pattern);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Contains_ShouldHandleEmptyStrings()
        {
            Assert.True(KmpSearcher.Contains("anything", "")); // Пустой паттерн всегда "найден"
            Assert.False(KmpSearcher.Contains("", "something")); // В пустом тексте ничего нет
        }
    }
}