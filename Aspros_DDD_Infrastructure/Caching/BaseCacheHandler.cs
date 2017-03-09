using Aspros_DDD_Infrastructure.Serializer;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Aspros_DDD_Infrastructure.Caching
{
    public abstract class BaseCacheHandler : ICacheHander
    {
        protected abstract IDistributedCache _Cache { get; }
        protected CachingConfigInfo _ConfigInfo { get; private set; }

        private TimeSpan _DefaultTimeSpan;

        private ConcurrentDictionary<string, object> _LockObjsDic;

        public BaseCacheHandler(CachingConfigInfo configInfo)
        {
            _DefaultTimeSpan = new TimeSpan(0, configInfo.DefaultSlidingTime, 0);
            _LockObjsDic = new ConcurrentDictionary<string, object>();

            _ConfigInfo = configInfo;
        }

        public void Put<T>(string catalog, string key, T value) => Put(catalog, key, value, _DefaultTimeSpan);

        public virtual void Put<T>(string catalog, string key, T value, TimeSpan timeSpan)
        {
            string cacheKey = GenCacheKey(catalog, key);

            string str = SerializerHelper.ToJson(value);

            _Cache.SetString(cacheKey, str, new DistributedCacheEntryOptions().SetSlidingExpiration(timeSpan));
        }

        public T Get<T>(string catalog, string key)
        {
            //MicroStrutLibraryExceptionHelper.TrueThrow(string.IsNullOrWhiteSpace(catalog) || string.IsNullOrWhiteSpace(key), this.GetType().FullName, LogLevel.Error, "缓存分类或者标识不能为空");

            string cacheKey = GenCacheKey(catalog, key);

            string str = _Cache.GetString(cacheKey);

            return SerializerHelper.FromJson<T>(str);
        }

        public T GetOrAdd<T>(string catalog, string key, Func<T> func) => GetOrAdd(catalog, key, func, _DefaultTimeSpan);

        public T GetOrAdd<T>(string catalog, string key, Func<T> func, TimeSpan timeSpan)
        {
            //MicroStrutLibraryExceptionHelper.TrueThrow(string.IsNullOrWhiteSpace(catalog) || string.IsNullOrWhiteSpace(key), this.GetType().FullName, LogLevel.Error, "缓存分类或者标识不能为空");

            T result = Get<T>(catalog, key);

            if (result == null)
            {
                string cacheKey = GenCacheKey(catalog, key);

                object lockObj = _LockObjsDic.GetOrAdd(cacheKey, n => new object());
                lock (lockObj)
                {
                    result = Get<T>(catalog, key);

                    if (result == null)
                    {
                        result = func();
                        Put(catalog, key, result, timeSpan);
                    }
                }
            }

            if (result == null)
                return default(T);

            return result;
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="catalog"></param>
        /// <param name="key"></param>
        public void Remove(string catalog, string key)
        {
            string cacheKey = GenCacheKey(catalog, key);

            _Cache.Remove(cacheKey);
        }

        /// <summary>
        /// 清空缓存
        /// </summary>
        public void Refresh(string catalog, string key)
        {
            string cacheKey = GenCacheKey(catalog, key);

            _Cache.Refresh(cacheKey);
        }

        /// <summary>
        /// 生成缓存键
        /// </summary>
        /// <param name="catalog"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private string GenCacheKey(string catalog, string key)
        {
            return $"{catalog}-{key}";
        }
    }
}
