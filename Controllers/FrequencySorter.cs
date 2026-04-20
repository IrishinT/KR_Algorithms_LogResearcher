using System;
using System.Collections.Generic;
using Models;

namespace Controllers.Algorithms
{
    /// <summary>
    /// Класс, реализующий алгоритм Быстрой сортировки (QuickSort).
    /// Адаптирован специально для сортировки моделей статистики по убыванию частоты запросов.
    /// </summary>
    public static class FrequencySorter
    {

        /// <summary>
        /// Сортирует список статистики IP-адресов по убыванию (от самых частых к редким).
        /// </summary>
        public static void SortIPsByFrequencyDescending(List<IPStatistics> list)
        {
            if (list == null || list.Count <= 1) return;
            QuickSortIPs(list, 0, list.Count - 1);
        }

        private static void QuickSortIPs(List<IPStatistics> list, int left, int right)
        {
            if (left < right)
            {
                // Находим опорный элемент и разделяем массив
                int pivotIndex = PartitionIPs(list, left, right);

                // Рекурсивно сортируем левую и правую части
                QuickSortIPs(list, left, pivotIndex - 1);
                QuickSortIPs(list, pivotIndex + 1, right);
            }
        }

        private static int PartitionIPs(List<IPStatistics> list, int left, int right)
        {
            // В качестве опорного элемента берем последний в текущем диапазоне
            int pivotValue = list[right].RequestCount;
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                // Условие ">" обеспечивает сортировку по УБЫВАНИЮ
                if (list[j].RequestCount > pivotValue)
                {
                    i++;

                    // Меняем элементы местами (Swap)
                    var temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }

            // Ставим опорный элемент на его финальную позицию
            var temp1 = list[i + 1];
            list[i + 1] = list[right];
            list[right] = temp1;

            return i + 1;
        }

        /// <summary>
        /// Сортирует список статистики по страницам по убыванию частоты запросов.
        /// </summary>
        public static void SortPagesByFrequencyDescending(List<PageStatistics> list)
        {
            if (list == null || list.Count <= 1) return;
            QuickSortPages(list, 0, list.Count - 1);
        }

        private static void QuickSortPages(List<PageStatistics> list, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = PartitionPages(list, left, right);
                QuickSortPages(list, left, pivotIndex - 1);
                QuickSortPages(list, pivotIndex + 1, right);
            }
        }

        private static int PartitionPages(List<PageStatistics> list, int left, int right)
        {
            int pivotValue = list[right].RequestCount;
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (list[j].RequestCount > pivotValue)
                {
                    i++;
                    var temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }

            var temp1 = list[i + 1];
            list[i + 1] = list[right];
            list[right] = temp1;

            return i + 1;
        }
    }
}