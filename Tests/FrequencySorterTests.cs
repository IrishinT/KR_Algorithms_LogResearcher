using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace Tests
{
    public class FrequencySorterTests
    {
        // 1. Корректность на типичных данных
        [Fact]
        public void Sort_TypicalData_ShouldSortDescending()
        {
            var list = new List<IPStatistics>
            {
                new IPStatistics { RequestCount = 10 },
                new IPStatistics { RequestCount = 50 },
                new IPStatistics { RequestCount = 5 }
            };

            FrequencySorter.SortIPsByFrequencyDescending(list);

            Assert.Equal(50, list[0].RequestCount);
            Assert.Equal(10, list[1].RequestCount);
            Assert.Equal(5, list[2].RequestCount);
        }

        // 2. Граничные случаи (пустой массив, массив из 1 элемента)
        [Fact]
        public void Sort_EdgeCases_EmptyOrSingle()
        {
            var emptyList = new List<IPStatistics>();
            FrequencySorter.SortIPsByFrequencyDescending(emptyList);
            Assert.Empty(emptyList); // Не упал - уже хорошо

            var singleList = new List<IPStatistics> { new IPStatistics { RequestCount = 42 } };
            FrequencySorter.SortIPsByFrequencyDescending(singleList);
            Assert.Single(singleList);
            Assert.Equal(42, singleList[0].RequestCount);
        }

        // 3. Некорректные входные данные (null)
        [Fact]
        public void Sort_InvalidData_NullList_ShouldNotThrow()
        {
            var exception = Record.Exception(() => FrequencySorter.SortIPsByFrequencyDescending(null));
            Assert.Null(exception); // Код должен содержать проверку if(list == null) return;
        }

        // 4. Специфические случаи (Уже отсортированный, обратно отсортированный, все одинаковые)
        [Fact]
        public void Sort_SpecificCases_AlreadySortedAndIdentical()
        {
            // Уже отсортированный
            var sortedList = new List<IPStatistics> { new IPStatistics { RequestCount = 100 }, new IPStatistics { RequestCount = 10 } };
            FrequencySorter.SortIPsByFrequencyDescending(sortedList);
            Assert.Equal(100, sortedList[0].RequestCount);

            // Обратно отсортированный
            var reverseSorted = new List<IPStatistics> { new IPStatistics { RequestCount = 10 }, new IPStatistics { RequestCount = 100 } };
            FrequencySorter.SortIPsByFrequencyDescending(reverseSorted);
            Assert.Equal(100, reverseSorted[0].RequestCount);

            // Все элементы одинаковые (худший случай для многих сортировок)
            var identical = new List<IPStatistics> { new IPStatistics { RequestCount = 5 }, new IPStatistics { RequestCount = 5 } };
            FrequencySorter.SortIPsByFrequencyDescending(identical);
            Assert.Equal(5, identical[0].RequestCount);
        }

        // 5. Большой объем данных + Измерение времени (Small, Medium, Large)
        [Fact]
        public void Sort_LargeData_ShouldNotHang()
        {
            var rnd = new Random(42);
            var list = new List<IPStatistics>(1_000_000); // 1 миллион элементов
            for (int i = 0; i < 1_000_000; i++)
            {
                list.Add(new IPStatistics { RequestCount = rnd.Next(1, 10000) });
            }

            // QuickSort отсортирует это без проблем. 
            // Пузырек повесил бы тест навсегда.
            FrequencySorter.SortIPsByFrequencyDescending(list);

            Assert.True(list[0].RequestCount >= list[^1].RequestCount);
        }
    }
}