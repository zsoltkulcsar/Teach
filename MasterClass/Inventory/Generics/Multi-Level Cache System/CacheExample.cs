namespace Inventory.Generics.Multi_Level_Cache_System
{
    public class CacheExample
    {
        public static void Main()
        {
            var cache = new MultiLevelCache<string>();

            cache.Set("user:123", "John Doe");
            cache.Set("user:456", "Jane Smith");

            Console.WriteLine(cache.Get("user:123"));
            Console.WriteLine(cache.Get("user:456")); 

            cache.ClearMemoryCache();

            Console.WriteLine(cache.Get("user:123"));
        }
    }
}
