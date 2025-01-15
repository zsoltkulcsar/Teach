/*
 * Creating a generic cache system that supports two levels of caching:

Memory Cache: A fast in-memory cache using a dictionary.
Persistent Cache: A slower persistent storage (e.g., a file or database).
You should provide:

Methods to store and retrieve data from both caches.
A method to clear the in-memory cache.
Thread-safety for the cache operations.
  
 */

namespace Inventory.Generics.Multi_Level_Cache_System
{
    public class MultiLevelCache<T>
    {
        // In-memory cache
        private Dictionary<string, T> memoryCache = new Dictionary<string, T>();

        // Persistent cache (simulated with a dictionary for this example)
        private Dictionary<string, T> persistentCache = new Dictionary<string, T>();

        private readonly object lockObj = new object();
        //Only one thread can access the cache at a time, which prevents race conditions when setting or getting data.

        public T Get(string key)
        {
            lock (lockObj)
            {
                if (memoryCache.ContainsKey(key))
                {
                    return memoryCache[key];
                }

                if (persistentCache.ContainsKey(key))
                {
                    return persistentCache[key];
                }
            }

            return default;
        }

        public void Set(string key, T value)
        {
            memoryCache[key] = value;

            persistentCache[key] = value;
        }

        public void ClearMemoryCache()
        {
            lock (lockObj)
            {
                memoryCache.Clear();
            }
        }

        private void SaveToPersistentStorage(string key, T value)
        {
            File.WriteAllText($"{key}.txt", value.ToString());
        }

        private T LoadFromPersistentStorage(string key)
        {
            if (File.Exists($"{key}.txt"))
            {
                var value = File.ReadAllText($"{key}.txt");
                return (T)Convert.ChangeType(value, typeof(T));
            }

            return default(T);
        }

    }
}
