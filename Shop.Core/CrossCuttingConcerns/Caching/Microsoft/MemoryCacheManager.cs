using System;
using System.Linq;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace Shop.Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        protected ObjectCache Cache => MemoryCache.Default;

        public T Get<T>(string key) => (T)Cache[key];

        public void Add(string key, object data, int duration)
        {
            if (data == null) return;

            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddMinutes(duration) };
            Cache.Add(new CacheItem(key, data), policy);
        }

        public bool Contains(string key) => Cache.Contains(key);

        public void Remove(string key) => Cache.Remove(key);

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keys = Cache.Where(x => regex.IsMatch(x.Key)).Select(x => x.Key).ToList();
            foreach (var key in keys) Remove(key);
        }

        public void Clear()
        {
            foreach (var item in Cache) Remove(item.Key);
        }
    }
}
