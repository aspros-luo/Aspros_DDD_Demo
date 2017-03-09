using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aspros_DDD_Infrastructure.Caching
{
    public interface ICacheService
    {
        #region 判断缓存是否存在，同步，异步
        /// <summary>
        /// 验证缓存是否存在
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <returns></returns>
        bool Exists(string key);
        /// <summary>
        /// 验证缓存是否存在(异步)
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <returns></returns>
        Task<bool> ExistsAsync(string key);
        #endregion

        #region 添加缓存，同步，异步
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存value</param>
        /// <returns></returns>
        bool Add(string key, string value);
        /// <summary>
       /// 添加缓存
       /// </summary>
       /// <param name="key">缓存key</param>
       /// <param name="value">缓存value</param>
       /// <param name="expiresSliding">缓存滑动时长</param>
       /// <param name="expiresAbsoulte">绝对过期时长</param>
       /// <returns></returns>
        bool Add(string key, string value, TimeSpan expiresSliding, TimeSpan expiresAbsoulte);
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存value</param>
        /// <param name="expiresIn">缓存时长</param>
        /// <param name="isSliding">是否滑动过期</param>
        /// <returns></returns>
        bool Add(string key, string value, TimeSpan expiresIn, bool isSliding = false);
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存value</param>
        /// <returns></returns>
        Task<bool> AddAsync(string key, string value);
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存value</param>
        /// <param name="expiresSliding">缓存滑动时长</param>
        /// <param name="expiresAbsoulte">绝对过期时长</param>
        /// <returns></returns>
        Task<bool> AddAsync(string key, string value, TimeSpan expiresSliding, TimeSpan expiresAbsoulte);
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存value</param>
        /// <param name="expiresIn">缓存时长</param>
        /// <param name="isSliding">是否滑动过期</param>
        /// <returns></returns>
        Task<bool> AddAsync(string key, string value, TimeSpan expiresIn, bool isSliding = false);
        #endregion 

        #region 删除缓存，同步，异步
        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <returns></returns>
        bool Remove(string key);
        /// <summary>
        /// 删除缓存集
        /// </summary>
        /// <param name="keys">缓存key集合</param>
        void RemoveList(IEnumerable<string> keys);
        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <returns></returns>
        Task<bool> RemoveAsync(string key);
        /// <summary>
        /// 删除缓存集
        /// </summary>
        /// <param name="keys">缓存key集合</param>
        Task RemoveListAsync(IEnumerable<string> keys);
        #endregion

        #region 需改缓存，同步，异步
        bool Replace(string key, string value);
        bool Replace(string key, string value, TimeSpan expiresSliding, TimeSpan expiresAbsoulte);
        bool Replace(string key, string value, TimeSpan expiresIn, bool isSliding = false);
        Task<bool> ReplaceAsync(string key, string value);
        Task<bool> ReplaceAsync(string key, string value, TimeSpan expiresSliding, TimeSpan expiresAbsoulte);
        Task<bool> ReplaceAsync(string key, string value, TimeSpan expiresIn, bool isSliding = false);
        #endregion

        #region 获取缓存，同步，异步
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">缓存key</param>
        /// <returns></returns>
        T Get<T>(string key) where T : class;
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <returns></returns>
        object Get(string key);
        /// <summary>
        /// 获取缓存集
        /// </summary>
        /// <param name="keys">缓存key集合</param>
        /// <returns></returns>
        IDictionary<string, object> GetList(IEnumerable<string> keys);

        Task<T> GetAsync<T>(string key) where T : class;
        Task<object> GetAsync(string key);
        Task<IDictionary<string, object>> GetListAsync(IEnumerable<string> keys);
        #endregion
    }
}
