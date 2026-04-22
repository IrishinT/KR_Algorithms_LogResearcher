using System;

namespace Controllers
{
    /// <summary>
    /// Собственная реализация алгоритмов поиска и разбора строк.
    /// Предназначен для замены встроенных методов string.IndexOf, string.Contains
    /// и регулярных выражений (Regex) при парсинге лог-файлов.
    /// Обеспечивает прозрачную алгоритмическую сложность, минимальные аллокации памяти
    /// и полное соответствие требованию курсовой работы о ручной реализации алгоритмов.
    /// </summary>
    public static class CustomStringParser
    {
        /// <summary>
        /// Линейный поиск первого вхождения символа в строку.
        /// </summary>
        public static int IndexOf(string text, char target, int startIndex = 0)
        {
            // Защита от выхода за границы
            if (startIndex < 0) startIndex = 0;
            for (int i = startIndex; i < text.Length; i++)
                if (text[i] == target) return i;
            return -1;
        }

        /// <summary>
        /// Наивный поиск подстроки в тексте.
        /// </summary>
        public static int IndexOf(string text, string pattern, int startIndex = 0)
        {
            if (string.IsNullOrEmpty(pattern)) return startIndex;
            if (startIndex < 0) startIndex = 0;

            int maxStart = text.Length - pattern.Length;
            for (int i = startIndex; i <= maxStart; i++)
            {
                bool match = true;
                for (int j = 0; j < pattern.Length; j++)
                    if (text[i + j] != pattern[j]) { match = false; break; }

                if (match) return i;
            }
            return -1;
        }

        /// <summary>
        /// Извлекает подстроку между заданными открывающим и закрывающим символами.
        /// Возвращает содержимое без самих разделителей.
        /// Параметр endIndex возвращает позицию закрывающего символа для продолжения парсинга.
        /// </summary>
        public static string ExtractBetween(string text, char open, char close, out int endIndex, int startIndex = 0)
        {
            int openIdx = IndexOf(text, open, startIndex);
            if (openIdx == -1) { endIndex = -1; return string.Empty; }

            int closeIdx = IndexOf(text, close, openIdx + 1);
            if (closeIdx == -1) { endIndex = -1; return string.Empty; }

            endIndex = closeIdx;
            return text.Substring(openIdx + 1, closeIdx - openIdx - 1);
        }

        /// <summary>
        /// Извлекает строку, заключённую в двойные кавычки.
        /// Оптимизирован под формат HTTP-логов, где кавычки экранируют request/referer/user-agent.
        /// </summary>
        public static string ExtractQuoted(string text, out int endIndex, int startIndex = 0)
        {
            int openIdx = IndexOf(text, '"', startIndex);
            if (openIdx == -1) { endIndex = -1; return string.Empty; }

            int closeIdx = IndexOf(text, '"', openIdx + 1);
            if (closeIdx == -1) { endIndex = -1; return string.Empty; }

            endIndex = closeIdx;
            return text.Substring(openIdx + 1, closeIdx - openIdx - 1);
        }

        /// <summary>
        /// Ручная валидация IPv4-адреса без регулярных выражений и string.Split.
        /// Проверяет: ровно 4 октета, каждый 0-255, отсутствие ведущих нулей.
        /// </summary>
        public static bool IsValidIPv4(string ip)
        {
            if (string.IsNullOrEmpty(ip)) return false;

            int dotCount = 0;
            int numStart = 0;

            // Итерируем до ip.Length включительно, чтобы обработать последний октет
            for (int i = 0; i <= ip.Length; i++)
            {
                // Граница октета (точка или конец строки)
                if (i == ip.Length || ip[i] == '.')
                {
                    int length = i - numStart;
                    if (length == 0) return false; // Пустой октет

                    if (!int.TryParse(ip.Substring(numStart, length), out int num) || num < 0 || num > 255)
                        return false;

                    // Запрет ведущих нулей (например, "01" или "001")
                    if (length > 1 && ip[numStart] == '0') return false;

                    numStart = i + 1;
                    if (i < ip.Length) dotCount++;
                }
                else if (!char.IsDigit(ip[i]))
                {
                    return false; // Найден нецифровой символ внутри октета
                }
            }
            return dotCount == 3;
        }

        /// <summary>
        /// Подсчитывает количество вхождений заданного символа.
        /// Используется для эвристического определения формата лога (Nginx/Apache).
        /// </summary>
        public static int CountChar(string text, char target)
        {
            int count = 0;
            for (int i = 0; i < text.Length; i++)
                if (text[i] == target) count++;
            return count;
        }
    }
}