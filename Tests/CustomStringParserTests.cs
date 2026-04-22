using Controllers;
using Xunit;

namespace Tests
{
    /// <summary>
    /// Тесты для класса CustomStringParser, проверяющие корректность
    /// ручной реализации поиска и парсинга строк без использования Regex.
    /// </summary>
    public class CustomStringParserTests
    {
        #region IndexOf (char)

        [Fact]
        public void IndexOf_Char_ShouldReturnCorrectPosition_WhenCharFound()
        {
            // Arrange
            string text = "192.168.1.1 - - [17/May/2015:10:05:00 +0000]";
            char target = '[';

            // Act
            int result = CustomStringParser.IndexOf(text, target);

            // Assert
            Assert.Equal(16, result);
        }

        [Fact]
        public void IndexOf_Char_ShouldReturnMinusOne_WhenCharNotFound()
        {
            // Arrange
            string text = "Simple text without special chars";
            char target = '@';

            // Act
            int result = CustomStringParser.IndexOf(text, target);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void IndexOf_Char_ShouldRespectStartIndex()
        {
            // Arrange
            string text = "a.b.c.d";
            char target = '.';

            // Act
            int first = CustomStringParser.IndexOf(text, target, 0);
            int second = CustomStringParser.IndexOf(text, target, 3);
            int afterEnd = CustomStringParser.IndexOf(text, target, 100);

            // Assert
            Assert.Equal(1, first);
            Assert.Equal(3, second);
            Assert.Equal(-1, afterEnd);
        }

        [Fact]
        public void IndexOf_Char_ShouldHandleEmptyString()
        {
            // Arrange
            string text = "";
            char target = 'x';

            // Act
            int result = CustomStringParser.IndexOf(text, target);

            // Assert
            Assert.Equal(-1, result);
        }

        #endregion

        #region IndexOf (string)

        [Fact]
        public void IndexOf_String_ShouldReturnCorrectPosition_WhenPatternFound()
        {
            // Arrange
            string text = "GET /api/users HTTP/1.1";
            string pattern = "/api";

            // Act
            int result = CustomStringParser.IndexOf(text, pattern);

            // Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void IndexOf_String_ShouldReturnMinusOne_WhenPatternNotFound()
        {
            // Arrange
            string text = "Hello World";
            string pattern = "xyz";

            // Act
            int result = CustomStringParser.IndexOf(text, pattern);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void IndexOf_String_ShouldHandleEmptyPattern()
        {
            // Arrange
            string text = "Any text";
            string pattern = "";

            // Act
            int result = CustomStringParser.IndexOf(text, pattern, 2);

            // Assert
            Assert.Equal(2, result); // Пустой паттерн считается найденным в startIndex
        }

        [Fact]
        public void IndexOf_String_ShouldHandlePatternLongerThanText()
        {
            // Arrange
            string text = "abc";
            string pattern = "abcdef";

            // Act
            int result = CustomStringParser.IndexOf(text, pattern);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void IndexOf_String_ShouldFindOverlappingPatterns()
        {
            // Arrange
            string text = "aaaa";
            string pattern = "aa";

            // Act
            int result = CustomStringParser.IndexOf(text, pattern);

            // Assert
            Assert.Equal(0, result); // Возвращает первое вхождение
        }

        #endregion

        #region ExtractBetween

        [Fact]
        public void ExtractBetween_ShouldExtractContent_WhenDelimitersFound()
        {
            // Arrange
            string text = "Log [17/May/2015:10:05:00] End";
            char open = '[';
            char close = ']';

            // Act
            string result = CustomStringParser.ExtractBetween(text, open, close, out int endIndex, 0);

            // Assert
            Assert.Equal("17/May/2015:10:05:00", result);
            Assert.Equal(25, endIndex);
        }

        [Fact]
        public void ExtractBetween_ShouldReturnEmpty_WhenOpenDelimiterNotFound()
        {
            // Arrange
            string text = "No brackets here";
            char open = '[';
            char close = ']';

            // Act
            string result = CustomStringParser.ExtractBetween(text, open, close, out int endIndex, 0);

            // Assert
            Assert.Empty(result);
            Assert.Equal(-1, endIndex);
        }

        [Fact]
        public void ExtractBetween_ShouldReturnEmpty_WhenCloseDelimiterNotFound()
        {
            // Arrange
            string text = "[Unclosed bracket";
            char open = '[';
            char close = ']';

            // Act
            string result = CustomStringParser.ExtractBetween(text, open, close, out int endIndex, 0);

            // Assert
            Assert.Empty(result);
            Assert.Equal(-1, endIndex);
        }

        [Fact]
        public void ExtractBetween_ShouldHandleNestedDelimiters()
        {
            // Arrange
            string text = "Data [outer [inner] content] done";
            char open = '[';
            char close = ']';

            // Act
            string result = CustomStringParser.ExtractBetween(text, open, close, out int endIndex, 0);

            // Assert
            Assert.Equal("outer [inner", result); // Берёт до первого закрывающего
            Assert.Equal(18, endIndex);
        }

        #endregion

        #region ExtractQuoted

        [Fact]
        public void ExtractQuoted_ShouldExtractContent_WhenQuotesFound()
        {
            // Arrange
            string text = "GET \"/api/users\" HTTP/1.1";

            // Act
            string result = CustomStringParser.ExtractQuoted(text, out int endIndex, 0);

            // Assert
            Assert.Equal("/api/users", result);
            Assert.Equal(15, endIndex);
        }

        [Fact]
        public void ExtractQuoted_ShouldRespectStartIndex()
        {
            // Arrange
            string text = "Ref: \"page\" Agent: \"bot\"";

            // Act
            string first = CustomStringParser.ExtractQuoted(text, out _, 0);
            string second = CustomStringParser.ExtractQuoted(text, out _, 15);

            // Assert
            Assert.Equal("page", first);
            Assert.Equal("bot", second);
        }

        [Fact]
        public void ExtractQuoted_ShouldReturnEmpty_WhenNoQuotes()
        {
            // Arrange
            string text = "No quotes in this line";

            // Act
            string result = CustomStringParser.ExtractQuoted(text, out int endIndex, 0);

            // Assert
            Assert.Empty(result);
            Assert.Equal(-1, endIndex);
        }

        [Fact]
        public void ExtractQuoted_ShouldHandleEmptyStringBetweenQuotes()
        {
            // Arrange
            string text = "Value: \"\" End";

            // Act
            string result = CustomStringParser.ExtractQuoted(text, out int endIndex, 0);

            // Assert
            Assert.Empty(result);
            Assert.Equal(8, endIndex);
        }

        #endregion

        #region IsValidIPv4

        [Theory]
        [InlineData("192.168.1.1", true)]
        [InlineData("127.0.0.1", true)]
        [InlineData("0.0.0.0", true)]
        [InlineData("255.255.255.255", true)]
        [InlineData("10.0.0.1", true)]
        public void IsValidIPv4_ShouldReturnTrue_ForValidAddresses(string ip, bool expected)
        {
            // Act
            bool result = CustomStringParser.IsValidIPv4(ip);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("256.1.1.1")]          // Октет > 255
        [InlineData("192.168.1")]          // Только 3 октета
        [InlineData("192.168.1.1.1")]      // 5 октетов
        [InlineData("192.168.-1.1")]       // Отрицательное число
        [InlineData("192.168.1.a")]        // Буквы
        [InlineData("192.168.1.")]         // Завершается точкой
        [InlineData(".192.168.1.1")]       // Начинается с точки
        [InlineData("192..168.1.1")]       // Две точки подряд
        [InlineData("")]                   // Пустая строка
        [InlineData("192.168.1.01")]       // Ведущий ноль
        [InlineData("01.02.03.04")]        // Ведущие нули во всех октетах
        public void IsValidIPv4_ShouldReturnFalse_ForInvalidAddresses(string ip)
        {
            // Act
            bool result = CustomStringParser.IsValidIPv4(ip);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidIPv4_ShouldRejectLeadingZeros()
        {
            // Arrange & Act
            bool result1 = CustomStringParser.IsValidIPv4("192.168.01.1");
            bool result2 = CustomStringParser.IsValidIPv4("001.002.003.004");
            bool result3 = CustomStringParser.IsValidIPv4("192.168.1.0"); // Единичный ноль — допустим

            // Assert
            Assert.False(result1);
            Assert.False(result2);
            Assert.True(result3);
        }

        #endregion

        #region CountChar

        [Fact]
        public void CountChar_ShouldReturnCorrectCount_WhenCharPresent()
        {
            // Arrange
            string text = "Nginx: \"req\" \"ref\" \"agent\"";
            char target = '"';

            // Act
            int result = CustomStringParser.CountChar(text, target);

            // Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void CountChar_ShouldReturnZero_WhenCharAbsent()
        {
            // Arrange
            string text = "No special chars here";
            char target = '@';

            // Act
            int result = CustomStringParser.CountChar(text, target);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CountChar_ShouldHandleEmptyString()
        {
            // Arrange
            string text = "";
            char target = 'x';

            // Act
            int result = CustomStringParser.CountChar(text, target);

            // Assert
            Assert.Equal(0, result);
        }

        #endregion

        #region Интеграционные тесты (парсинг лога)

        [Fact]
        public void ParseLogLine_ShouldExtractTimestamp_FromBrackets()
        {
            // Arrange
            string logLine = "192.168.1.1 - - [17/May/2015:10:05:00 +0000] \"GET /index.html\" 200 1024";

            // Act
            string timestamp = CustomStringParser.ExtractBetween(logLine, '[', ']', out int endIdx, 0);

            // Assert
            Assert.Equal("17/May/2015:10:05:00 +0000", timestamp);
            Assert.True(endIdx > 0);
        }

        [Fact]
        public void ParseLogLine_ShouldExtractIP_FromStart()
        {
            // Arrange
            string logLine = "192.168.1.1 - - [17/May/2015:10:05:00 +0000] \"GET /index.html\" 200 1024";

            // Act
            int ipEnd = CustomStringParser.IndexOf(logLine, ' ');
            string ip = logLine.Substring(0, ipEnd);
            bool isValid = CustomStringParser.IsValidIPv4(ip);

            // Assert
            Assert.Equal("192.168.1.1", ip);
            Assert.True(isValid);
        }

        [Fact]
        public void ParseLogLine_ShouldExtractRequest_FromQuotes()
        {
            // Arrange
            string logLine = "192.168.1.1 - - [17/May/2015:10:05:00 +0000] \"GET /api/users HTTP/1.1\" 200 1024";
            int afterIp = CustomStringParser.IndexOf(logLine, ' ') + 1;

            // Act
            string request = CustomStringParser.ExtractQuoted(logLine, out int reqEnd, afterIp);

            // Assert
            Assert.Equal("GET /api/users HTTP/1.1", request);
            Assert.True(reqEnd > afterIp);
        }

        #endregion
    }
}