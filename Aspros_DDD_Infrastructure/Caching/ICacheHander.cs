using System;
using System.Collections.Generic;
using System.Text;

namespace Aspros_DDD_Infrastructure.Caching
{
    public interface ICacheHander
    {
        /// <summary>
        /// 如果不存在缓存项则添加，否则更新
        /// </summary>
        /// <param name="catalog">缓存分类</param>
        /// <param name="key">缓存项标识</param>
        /// <param name="value">缓存项</param>
        void Put<T>(string catalog, string key, T value);

        /// <summary>
        /// 如果不存在缓存项则添加，否则更新
        /// </summary>
        /// <param name="catalog">缓存分类</param>
        /// <param name="key">缓存项标识</param>
        /// <param name="value">缓存项</param>
        /// <param name="timeSpan">缓存时间，滑动过期</param>
        void Put<T>(string catalog, string key, T value, TimeSpan timeSpan);

        /// <summary>
        /// 获取缓存项
        /// </summary>
        /// <param name="catalog">缓存分类</param>
        /// <param name="key">cacheKey</param>
        T Get<T>(string catalog, string key);

        /// <summary>
        /// 获取缓存项，如果不存在则使用方法获取数据并加入缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="catalog">缓存分类</param>
        /// <param name="key">缓存项标识</param>
        /// <param name="func">获取要缓存的数据的方法</param>
        /// <returns>缓存的数据结果</returns>
        T GetOrAdd<T>(string catalog, string key, Func<T> func);

        /// <summary>
        /// 获取缓存项，如果不存在则使用方法获取数据并加入缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="catalog">缓存分类</param>
        /// <param name="key">缓存项标识</param>
        /// <param name="func">获取要缓存的数据的方法</param>
        /// <param name="timeSpan">缓存时间，滑动过期</param>
        /// <returns>缓存的数据结果</returns>
        T GetOrAdd<T>(string catalog, string key, Func<T> func, TimeSpan timeSpan);

        /// <summary>
        /// 移除缓存项
        /// </summary>
        /// <param name="catalog">缓存分类</param>
        /// <param name="key">cacheKey</param>
        void Remove(string catalog, string key);

        /// <summary>
        /// 刷新缓存项
        /// </summary>
        /// <param name="catalog">缓存分类</param>
        /// <param name="key">cacheKey</param>
        void Refresh(string catalog, string key);
    }
}
