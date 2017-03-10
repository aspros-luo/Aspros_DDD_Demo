
using Aspros_DDD_Infrastructure.Serializer;
using Microsoft.Extensions.Caching.Redis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspros_DDD_Infrastructure.Caching
{
    public class RedisCacheService : ICacheService
    {
        protected IDatabase _cache;
        private ConnectionMultiplexer _connection;
        private readonly string _instance;

        public RedisCacheService(RedisCacheOptions options ,int database=0)
        {
            _connection = ConnectionMultiplexer.Connect(options.Configuration);
            _cache = _connection.GetDatabase(database);
            _instance = options.InstanceName;
        }

        /// <summary>
        /// 组合key和示例名称
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetKeyForRedis(string key)
        {
            return _instance + key;
        }

        public bool Add(string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(key))
                return _cache.StringSet(GetKeyForRedis(key), SerializerHelper.ToJson(value));
            throw new NotImplementedException();
        }

        public bool Add(string key, string value, TimeSpan expiresSliding, TimeSpan expiresAbsoulte)
        {
            if (!string.IsNullOrWhiteSpace(key))
                return _cache.StringSet(GetKeyForRedis(key), SerializerHelper.ToJson(value),expiresAbsoulte);
            throw new NotImplementedException();
        }

        public bool Add(string key, string value, TimeSpan expiresIn, bool isSliding = false)
        {
            if (!string.IsNullOrWhiteSpace(key))
                return _cache.StringSet(GetKeyForRedis(key), SerializerHelper.ToJson(value), expiresIn);
            throw new NotImplementedException();
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
                return _cache.KeyExists(GetKeyForRedis(key));
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(string key)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key) where T : class
        {
            if (!string.IsNullOrWhiteSpace(key))
                return SerializerHelper.FromJson<T>(_cache.StringGet(GetKeyForRedis(key)));
            throw new NotImplementedException();
        }

        public object Get(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
                return SerializerHelper.FromJson<object>(_cache.StringGet(GetKeyForRedis(key)));
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
            {
                throw new NotImplementedException();
            }
            else
            {
                var dict = new Dictionary<string, object>();
                keys.ToList().ForEach(v => dict.Add(v, Get(v)));
                return dict;
            }
        }

        public Task<IDictionary<string, object>> GetListAsync(IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
                return _cache.KeyDelete(GetKeyForRedis(key));
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(string key)
        {
            throw new NotImplementedException();
        }

        public void RemoveList(IEnumerable<string> keys)
        {
            if(keys==null)
                throw new NotImplementedException();
            keys.ToList().ForEach(v => Remove(v));
        }

        public Task RemoveListAsync(IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }

        public bool Replace(string key, string value)
        {
            if(string.IsNullOrWhiteSpace(key))
                throw new NotImplementedException();
            if (Exists(key))
                if (!Remove(key))
                    return false;
            return Add(key, value);
        }

        public bool Replace(string key, string value, TimeSpan expiresSliding, TimeSpan expiresAbsoulte)
        {
            throw new NotImplementedException();
        }

        public bool Replace(string key, string value, TimeSpan expiresIn, bool isSliding = false)
        {
            throw new NotImplementedException();
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
            if (_connection != null)
                _connection.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
