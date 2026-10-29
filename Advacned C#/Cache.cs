namespace Advacned_C_
{
    // Q20: generic cache with expiration support
    public class Cache<TKey, TValue> where TKey : notnull
    {
        private class CacheItem
        {
            public TValue Value { get; }
            public DateTime? ExpiresAt { get; }

            public CacheItem(TValue value, DateTime? expiresAt)
            {
                Value = value;
                ExpiresAt = expiresAt;
            }

            public bool IsExpired => ExpiresAt.HasValue && DateTime.Now >= ExpiresAt.Value;
        }

        private readonly Dictionary<TKey, CacheItem> _items = new Dictionary<TKey, CacheItem>();
        private readonly TimeSpan? _defaultExpiration;

        
        public Cache(TimeSpan? defaultExpiration = null)
        {
            _defaultExpiration = defaultExpiration;
        }

        public int Count
        {
            get
            {
                RemoveExpired();
                return _items.Count;
            }
        }

        public void Add(TKey key, TValue value, TimeSpan? expiration = null)
        {
            TimeSpan? duration = expiration ?? _defaultExpiration;
            DateTime? expiresAt = duration.HasValue ? DateTime.Now.Add(duration.Value) : null;

            _items[key] = new CacheItem(value, expiresAt);   
        }

        public TValue? Get(TKey key)
        {
            return TryGet(key, out TValue? value) ? value : default;
        }

        public bool TryGet(TKey key, out TValue? value)
        {
            if (_items.TryGetValue(key, out CacheItem? item))
            {
                if (!item.IsExpired)
                {
                    value = item.Value;
                    return true;
                }

                _items.Remove(key);   
            }

            value = default;
            return false;
        }

        public bool Contains(TKey key) => TryGet(key, out _);

        public bool Remove(TKey key) => _items.Remove(key);

        public void Clear() => _items.Clear();

        public int RemoveExpired()
        {
            List<TKey> expired = _items.Where(pair => pair.Value.IsExpired)
                                       .Select(pair => pair.Key)
                                       .ToList();

            foreach (TKey key in expired)
                _items.Remove(key);

            return expired.Count;
        }
    }
}
