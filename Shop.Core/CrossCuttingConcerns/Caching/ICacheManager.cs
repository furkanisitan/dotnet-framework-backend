namespace Shop.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        /// <summary>
        /// Returns an object as T from cache by specified key.
        /// </summary>
        /// <typeparam name="T">The type of the cache object.</typeparam>
        /// <param name="key">A unique identifier for the cache item.</param>
        /// <returns>If key exists, the cache item; otherwise, null /></returns>
        T Get<T>(string key);

        /// <summary>
        /// Insert data to cache.
        /// </summary>
        /// <param name="key">A unique identifier for the cache item.</param>
        /// <param name="data">The object to cache.</param>
        /// <param name="duration">Cache durations in minutes.</param>
        void Add(string key, object data, int duration);

        /// <summary>
        /// Checks whether the cache item already exists in the cache.
        /// </summary>
        /// <param name="key">A unique identifier for the cache item.</param>
        /// <returns>If key exists, true; otherwise, false </returns>
        bool Contains(string key);

        /// <summary>
        /// Removes the cache item from the cache.
        /// </summary>
        /// <param name="key">A unique identifier for the cache item.</param>
        void Remove(string key);

        /// <summary>
        /// Removes the cache item from the cache by pattern.
        /// </summary>
        /// <param name="start">A pattern for the keys of cache items.</param>
        void RemoveByPattern(string start);

        /// <summary>
        /// Removes all items in the cache.
        /// </summary>
        void Clear();
    }
}
