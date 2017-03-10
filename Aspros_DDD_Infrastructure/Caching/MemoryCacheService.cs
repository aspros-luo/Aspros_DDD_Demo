using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aspros_DDD_Infrastructure.Caching
{
    public class MemoryCacheService : ICacheService
    {
        protected IMemoryCache _cache;
        public MemoryCacheService(IMemoryCache cache)
        {
            _cache = cache;
        }
        public bool Add(string key, string value)
        {
            if(!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
            {
                _cache.Set(key, value);
                return Exists(key);
            }
            else
            {
                throw new ArgumentNullException(nameof(key));
            }
        }

        public bool Add(string key, string value, TimeSpan expiresSliding, TimeSpan expiresAbsoulte)
        {
            if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
            {
                _cache.Set(key, value,new MemoryCacheEntryOptions().SetSlidingExpiration(expiresSliding).SetAbsoluteExpiration(expiresAbsoulte));
                return Exists(key);
            }
            else
            {
                throw new ArgumentNullException(nameof(key));
            }
        }

        public bool Add(string key, string value, TimeSpan expiresIn, bool isSliding = false)
        {
            if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
            {
                if(isSliding)
                    _cache.Set(key, value, new MemoryCacheEntryOptions().SetSlidingExpiration(expiresIn));
                _cache.Set(key, value, new MemoryCacheEntryOptions().SetAbsoluteExpiration(expiresIn));
                return Exists(key);
            }
            else
            {
                throw new ArgumentNullException(nameof(key));
            }
        }

        public Task<bool> AddAsync(string key, string value)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync(string key, string value, TimeSpan expiresSliding, TimeSpan expiresAbsoulte)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync(string key, string value, TimeSpan expiresIn, bool isSliding = false)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
                return _cache.TryGetValue(key, out object cached);
            throw new ArgumentNullException(nameof(key));
        }

        public Task<bool> ExistsAsync(string key)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key) where T : class
        {
            if (!string.IsNullOrWhiteSpace(key))
                return _cache.Get(key) as T;
            throw new NotImplementedException();
        }

        public object Get(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
                return _cache.Get(key);
            throw new NotImplementedException();
        }

        public Task<T> GetAsync<T>(string key) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<object> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> GetList(IEnumerable<string> keys)
        {
            if (keys == null)
                throw new NotImplementedException();

            var dict = new Dictionary<string, object>();
            keys.ToList().ForEach(v => dict.Add(v,_cache.Get(v)));
            return dict;
        }

        public Task<IDictionary<string, object>> GetListAsync(IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
                _cache.Remove(key);
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(string key)
        {
            throw new NotImplementedException();
        }

        public void RemoveList(IEnumerable<string> keys)
        {
            if (keys==null)
                throw new NotImplementedException();
            keys.ToList().ForEach(v => _cache.Remove(v));
        }

        public Task RemoveListAsync(IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }

        public bool Replace(string key, string value)
        {
            if(!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
            {
                if (Exists(key))
                    if (!Remove(key)) return false;

                return Add(key, value);
            }
            return false;
        }

        public bool Replace(string key, string value, TimeSpan expiresSliding, TimeSpan expiresAbsoulte)
        {
            if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
            {
                if (Exists(key))
                    if (!Remove(key)) return false;

                return Add(key, value,expiresSliding,expiresAbsoulte);
            }
            return false;
        }

        public bool Replace(string key, string value, TimeSpan expiresIn, bool isSliding = false)
        {
            if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
            {
                if (Exists(key))
                    if (!Remove(key)) return false;

                return Add(key, value, expiresIn, isSliding);
            }
            return false;
        }

        public Task<bool> ReplaceAsync(string key, string value)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ReplaceAsync(string key, string value, TimeSpan expiresSliding, TimeSpan expiresAbsoulte)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ReplaceAsync(string key, string value, TimeSpan expiresIn, bool isSliding = false)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (_cache != null)
                _cache.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
