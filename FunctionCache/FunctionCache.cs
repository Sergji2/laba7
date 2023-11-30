using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate TResult Func<TKey, TResult>(TKey key);

class FunctionCache<TKey, TResult>
{
    private Dictionary<TKey, CacheItem<TResult>> cache;

    public FunctionCache()
    {
        cache = new Dictionary<TKey, CacheItem<TResult>>();
    }

    public TResult Execute(Func<TKey, TResult> function, TKey key, TimeSpan expirationTime)
    {
        if (cache.TryGetValue(key, out CacheItem<TResult> cachedItem) && !IsExpired(cachedItem, expirationTime))
        {
            Console.WriteLine($"Cache hit for key '{key}'.");
            return cachedItem.Value;
        }

        Console.WriteLine($"Cache miss for key '{key}'. Executing function.");
        TResult result = function(key);
        cache[key] = new CacheItem<TResult>(result, DateTime.Now);

        return result;
    }

    private bool IsExpired(CacheItem<TResult> item, TimeSpan expirationTime)
    {
        return DateTime.Now - item.Timestamp > expirationTime;
    }

    private class CacheItem<TValue>
    {
        public TValue Value { get; }
        public DateTime Timestamp { get; }

        public CacheItem(TValue value, DateTime timestamp)
        {
            Value = value;
            Timestamp = timestamp;
        }
    }
}