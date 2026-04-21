using Controllers;
using Models;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class FrequencySorterTests
    {
        [Fact]
        public void SortIPsByFrequencyDescending_ShouldSortCorrectly()
        {
            // Arrange
            var list = new List<IPStatistics>
            {
                new IPStatistics { IP = "1.1.1.1", RequestCount = 10 },
                new IPStatistics { IP = "2.2.2.2", RequestCount = 50 },
                new IPStatistics { IP = "3.3.3.3", RequestCount = 5 },
                new IPStatistics { IP = "4.4.4.4", RequestCount = 100 }
            };

            // Act
            FrequencySorter.SortIPsByFrequencyDescending(list);

            // Assert (Проверяем убывание: 100, 50, 10, 5)
            Assert.Equal(100, list[0].RequestCount);
            Assert.Equal(50, list[1].RequestCount);
            Assert.Equal(10, list[2].RequestCount);
            Assert.Equal(5, list[3].RequestCount);
        }

        [Fact]
        public void SortPagesByFrequencyDescending_ShouldHandleAlreadySortedList()
        {
            // Arrange
            var list = new List<PageStatistics>
            {
                new PageStatistics { Url = "/a", RequestCount = 30 },
                new PageStatistics { Url = "/b", RequestCount = 20 },
                new PageStatistics { Url = "/c", RequestCount = 10 }
            };

            // Act
            FrequencySorter.SortPagesByFrequencyDescending(list);

            // Assert
            Assert.Equal(30, list[0].RequestCount);
            Assert.Equal(10, list[2].RequestCount);
        }

        [Fact]
        public void Sort_ShouldHandleEmptyList()
        {
            // Arrange
            var list = new List<IPStatistics>();

            // Act & Assert (Не должно выбрасывать исключений)
            FrequencySorter.SortIPsByFrequencyDescending(list);
            Assert.Empty(list);
        }

        [Fact]
        public void Sort_ShouldHandleIdenticalCounts()
        {
            // Arrange
            var list = new List<IPStatistics>
            {
                new IPStatistics { IP = "A", RequestCount = 10 },
                new IPStatistics { IP = "B", RequestCount = 10 }
            };

            // Act
            FrequencySorter.SortIPsByFrequencyDescending(list);

            // Assert
            Assert.Equal(10, list[0].RequestCount);
            Assert.Equal(10, list[1].RequestCount);
        }
    }
}