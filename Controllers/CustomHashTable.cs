using System;
using System.Collections.Generic;

namespace Controllers
{
    /// <summary>
    /// Собственная реализация хеш-таблицы (ассоциативного массива).
    /// Использует метод цепочек (односвязных списков) для разрешения коллизий.
    /// Обеспечивает вставку и поиск элементов в среднем за время O(1).
    /// </summary>
    /// <typeparam name="TKey">Тип ключа</typeparam>
    /// <typeparam name="TValue">Тип значения</typeparam>
    public class CustomHashTable<TKey, TValue>
    {

        /// <summary>
        /// Узел односвязного списка для хранения пар "ключ-значение" в корзинах (buckets)
        /// </summary>
        private class Entry
        {
            public TKey Key;
            public TValue Value;
            public Entry Next;
        }

        private Entry[] _buckets;
        private int _count;

        public CustomHashTable(int capacity = 1024)
        {
            _buckets = new Entry[capacity];
        }

        /// <summary>
        /// Вычисляет индекс корзины на основе хеш-кода ключа.
        /// </summary>
        private int GetBucketIndex(TKey key)
        {
            int hash = key.GetHashCode() & 0x7FFFFFFF; // Убираем отрицательные значения
            return hash % _buckets.Length;
        }

        /// <summary>
        /// Добавляет новый элемент в хеш-таблицу или обновляет существующий.
        /// </summary>
        public void AddOrUpdate(TKey key, TValue value)
        {
            int index = GetBucketIndex(key);
            Entry current = _buckets[index];

            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    current.Value = value; // Обновляем, если ключ уже есть
                    return;
                }
                current = current.Next;
            }

            // Добавляем в начало цепочки (разрешение коллизий)
            Entry newEntry = new Entry { Key = key, Value = value, Next = _buckets[index] };
            _buckets[index] = newEntry;
            _count++;
        }

        /// <summary>
        /// Пытается получить значение по ключу.
        /// </summary>
        /// <returns>True, если элемент найден, иначе False.</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            int index = GetBucketIndex(key);
            Entry current = _buckets[index];

            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    value = current.Value;
                    return true;
                }
                current = current.Next;
            }

            value = default;
            return false;
        }

        /// <summary>
        /// Возвращает все пары "ключ-значение" для удобной итерации по коллекции.
        /// </summary>
        public List<KeyValuePair<TKey, TValue>> GetAll()
        {
            var list = new List<KeyValuePair<TKey, TValue>>(_count);
            for (int i = 0; i < _buckets.Length; i++)
            {
                Entry current = _buckets[i];
                while (current != null)
                {
                    list.Add(new KeyValuePair<TKey, TValue>(current.Key, current.Value));
                    current = current.Next;
                }
            }
            return list;
        }
    }
}