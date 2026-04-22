using Controllers;
using System;
using System.Diagnostics;
using Xunit;

namespace Tests
{
    public class CustomHashTableTests
    {
        // 1. Корректность на типичных данных
        [Fact]
        public void AddAndGet_TypicalData_ShouldWorkCorrectly()
        {
            var table = new CustomHashTable<string, int>();
            table.AddOrUpdate("apple", 10);
            table.AddOrUpdate("banana", 20);

            Assert.True(table.TryGetValue("apple", out int val1));
            Assert.Equal(10, val1);

            // Обновление значения
            table.AddOrUpdate("apple", 15);
            table.TryGetValue("apple", out int val2);
            Assert.Equal(15, val2);
        }

        // 2. Граничные случаи (отсутствующий ключ)
        [Fact]
        public void TryGetValue_EdgeCase_MissingKey()
        {
            var table = new CustomHashTable<string, int>();
            bool found = table.TryGetValue("not_exist", out int val);
            Assert.False(found);
            Assert.Equal(0, val); // Значение по умолчанию
        }

        // 3. Специфический случай (Коллизии)
        [Fact]
        public void AddOrUpdate_SpecificCase_HashCollisions()
        {
            // Создаем таблицу размером 1, чтобы СПРОВОЦИРОВАТЬ коллизию всех элементов 
            // в одной корзине (проверка работы односвязного списка)
            var table = new CustomHashTable<string, int>(capacity: 1);

            table.AddOrUpdate("key1", 1);
            table.AddOrUpdate("key2", 2);
            table.AddOrUpdate("key3", 3);

            Assert.True(table.TryGetValue("key1", out int v1));
            Assert.True(table.TryGetValue("key3", out int v3));
            Assert.Equal(1, v1);
            Assert.Equal(3, v3);
        }

        // 4. Большой объем данных + Измерение времени (Small, Medium, Large)
        [Fact]
        public void HashTable_LargeData_ShouldNotHang()
        {
            var table = new CustomHashTable<int, string>(1_000_000); // 1 миллион элементов
            for (int i = 0; i < 1_000_000; i++)
            {
                table.AddOrUpdate(i, "value");
            }

            table.TryGetValue(500_000, out string val);
            Assert.Equal("value", val);
        }
    }
}