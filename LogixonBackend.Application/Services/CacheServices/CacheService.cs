using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace LogixonBackend.Application.Services.CacheServices
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await _cache.GetStringAsync(key);
            if (string.IsNullOrEmpty(value))
                return default;

            return JsonSerializer.Deserialize<T>(value);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
        {
            var options = new DistributedCacheEntryOptions();
            if (expiration.HasValue)
                options.AbsoluteExpirationRelativeToNow = expiration;
            else
                options.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);

            var serialized = JsonSerializer.Serialize(value);
            await _cache.SetStringAsync(key, serialized, options);
        }

        public async Task RemoveAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }
    }
}