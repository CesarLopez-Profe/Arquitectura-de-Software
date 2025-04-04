using Microsoft.Extensions.Caching.Memory;
using PrestamosVehiculos.Domain.Interfaces;

namespace PrestamosVehiculos.Infrastructure.Cache
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _cache;

        public MemoryCacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public T GetOrSet<T>(string key, Func<T> factory, TimeSpan expiration)
        {
            if (_cache.TryGetValue(key, out T value))
                return value;

            value = factory();
            _cache.Set(key, value, expiration);
            return value;
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
