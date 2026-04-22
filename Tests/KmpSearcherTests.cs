using Controllers;
using System;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace Tests
{
    public class KmpSearcherTests
    {
        // 1. Корректность на типичных данных
        [Theory]
        [InlineData("Hello World", "World", true)]
        [InlineData("Log analysis is cool", "log", true)] // Регистронезависимость
        [InlineData("/api/v1/users", "users", true)]
        public void Contains_TypicalData_ShouldReturnCorrectResult(string text, string pattern, bool expected)
        {
            Assert.Equal(expected, KmpSearcher.Contains(text, pattern));
        }

        // 2. Граничный случай (строка из 1 символа, пустая строка, совпадение длины)
        [Theory]
        [InlineData("a", "a", true)]
        [InlineData("a", "b", false)]
        [InlineData("anything", "", true)] // Пустой паттерн всегда найден
        [InlineData("", "something", false)] // В пустом тексте ничего нет
        [InlineData("abc", "abc", true)]
        public void Contains_EdgeCases_ShouldHandleCorrectly(string text, string pattern, bool expected)
        {
            Assert.Equal(expected, KmpSearcher.Contains(text, pattern));
        }

        // 3. Некорректные входные данные (null)
        [Fact]
        public void Contains_InvalidData_Nulls_ShouldHandleGracefully()
        {
            Assert.False(KmpSearcher.Contains(null, "pattern")); // null текст
            Assert.True(KmpSearcher.Contains("text", null));     // null паттерн (как и пустой)
            Assert.True(KmpSearcher.Contains(null, null));       // оба null
        }

        // 4. Специфический случай (перекрывающиеся паттерны)
        [Fact]
        public void Contains_SpecificCase_OverlappingPatterns()
        {
            // Паттерн "aaa" внутри "aaaaa". Стандартный поиск может сбоить, КМП должен найти.
            Assert.True(KmpSearcher.Contains("aaaaa", "aaa"));
            Assert.False(KmpSearcher.Contains("abc", "abcd")); // Паттерн больше текста
        }

        // 5. Большой объем данных + Измерение времени (Small, Medium, Large)
        [Fact]
        public void Contains_LargeData_ShouldNotHang()
        {
            // Строка на 5 миллионов символов. КМП найдет мгновенно, плохой алгоритм зависнет.
            string text = new string('a', 5_000_000) + "b";
            string pattern = "aaaaab";

            bool result = KmpSearcher.Contains(text, pattern);
            Assert.True(result);
        }
    }
}