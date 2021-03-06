﻿using Base.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace Base.Cache
{
    /// <summary>
    /// 服务器缓存帮助类
    /// </summary>
    public class DataCache
    {
        /// <summary>
        /// 创建缓存项过期
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="obj">object对象</param>
        public static void Insert(string key, object obj)
        {
            if (obj != null)
            {
                int expires = int.Parse(ConfigHelper.CacheTime);
                Insert(key, obj, expires);
            }
        }
        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="cd">数据更新</param>
        /// <param name="obj">值</param>
        /// <param name="isSpan">使用时是否延时过期</param>
        public static void Insert(string key, AggregateCacheDependency cd, object obj, bool isSpan)
        {
            if (obj != null)
            {
                int expires = int.Parse(ConfigHelper.CacheTime);
                Insert(key, cd, obj, expires, isSpan);
            }
        }
        /// <summary>
        /// 创建缓存项过期(NoAbsoluteExpiration 不使用则过期)
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="obj">object对象</param>
        /// <param name="expires">设置时间</param>
        public static void Insert(string key, object obj, int expires)
        {
            if (obj != null)
            {
                HttpContext.Current.Cache.Insert(key, obj, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, expires, 0));
            }
        }

        /// <summary>
        /// 创建缓存项过期 （到时过期）
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="obj">object对象</param>
        /// <param name="expires">设置时间（分钟）</param>
        /// <param name="isSpan">使用时是否延时过期</param>
        public static void Insert(string key, AggregateCacheDependency cd, object obj, int expires, bool isSpan)
        {
            if (obj != null)
            {
                if (isSpan)
                {
                    HttpContext.Current.Cache.Insert(key, obj, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, expires, 0));
                }
                else
                {
                    HttpContext.Current.Cache.Insert(key, obj, cd, DateTime.Now.AddHours(expires), System.Web.Caching.Cache.NoSlidingExpiration);
                }
            }
        }

        /// <summary>
        /// 判断缓存对象是否存在
        /// </summary>
        /// <param name="strKey">缓存键值名称</param>
        /// <returns>是否存在true 、false</returns>
        public static bool IsExist(string strKey)
        {
            return HttpContext.Current.Cache[strKey] != null;
        }
        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns>object对象</returns>
        public static object Get(string key, bool isCache = true)
        {
            if (string.IsNullOrEmpty(key))
                return null;
            if (StringHelper.GetBool(ConfigHelper.IsCache) && isCache)
            {
                return HttpContext.Current.Cache.Get(key);
            }
            return null;
        }
        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        public static void RemoveAllCache(string CacheKey)
        {
            System.Web.Caching.Cache _cache = HttpRuntime.Cache;
            _cache.Remove(CacheKey);
        }

        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public static void RemoveAllCache()
        {
            System.Web.Caching.Cache _cache = HttpRuntime.Cache;
            IDictionaryEnumerator CacheEnum = _cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                _cache.Remove(CacheEnum.Key.ToString());
            }
        }
    }
}
