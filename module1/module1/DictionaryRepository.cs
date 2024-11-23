using System;
using System.Collections.Generic;

namespace Module_1
{
    public class DictionaryRepository<TKey, TValue> where TKey : IComparable<TKey>
    {
        private readonly Dictionary<TKey, TValue> items = new Dictionary<TKey, TValue>();

        public void Add(TKey id, TValue item)
        {
            if (items.ContainsKey(id))
                throw new ArgumentException("ID already exists.");
            items.Add(id, item);
        }

        public TValue Get(TKey id)
        {
            if (!items.ContainsKey(id))
                throw new KeyNotFoundException("ID not found.");
            return items[id];
        }

        public void Update(TKey id, TValue newItem)
        {
            if (!items.ContainsKey(id))
                throw new KeyNotFoundException("ID not found.");
            items[id] = newItem;
        }

        public void Delete(TKey id)
        {
            if (!items.ContainsKey(id))
                throw new KeyNotFoundException("ID not found.");
            items.Remove(id);
        }

        public IEnumerable<KeyValuePair<TKey, TValue>> GetAll()
        {
            return items;
        }
    }



}
