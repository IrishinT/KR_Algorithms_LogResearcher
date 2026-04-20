using System;

namespace Controllers
{
    /// <summary>
    /// Класс, реализующий алгоритм Кнута-Морриса-Пратта (КМП) для быстрого строкового поиска.
    /// Выполняет поиск за линейное время O(N + M), избегая лишних откатов назад по тексту.
    /// </summary>
    public static class KmpSearcher
    {

        /// <summary>
        /// Проверяет, содержится ли подстрока (паттерн) в исходном тексте.
        /// </summary>
        public static bool Contains(string text, string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) return true;
            if (string.IsNullOrEmpty(text)) return false;

            // Приводим строки к нижнему регистру для независимости поиска от регистра
            text = text.ToLower();
            pattern = pattern.ToLower();

            // Массив префиксов для оптимизации сдвигов
            int[] lps = ComputeLPSArray(pattern);
            int i = 0; // Указатель для текста
            int j = 0; // Указатель для паттерна

            while (i < text.Length)
            {
                if (pattern[j] == text[i])
                {
                    j++;
                    i++;
                }
                if (j == pattern.Length)
                {
                    return true; // Полное совпадение найдено
                }
                else if (i < text.Length && pattern[j] != text[i])
                {
                    // Если символ не совпал, сдвигаем паттерн согласно LPS-массиву,
                    // не откатывая указатель текста i назад.
                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i++;
                }
            }
            return false;
        }

        /// <summary>
        /// Вычисляет массив длин самых длинных префиксов, которые одновременно являются суффиксами (LPS).
        /// </summary>
        private static int[] ComputeLPSArray(string pattern)
        {
            int length = 0; // Длина предыдущего максимального префикса-суффикса
            int i = 1;
            int[] lps = new int[pattern.Length];
            lps[0] = 0; // LPS для одного символа всегда 0

            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[length])
                {
                    length++;
                    lps[i] = length;
                    i++;
                }
                else
                {
                    if (length != 0)
                    {
                        // Откат к предыдущему префиксу
                        length = lps[length - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }
            return lps;
        }
    }
}