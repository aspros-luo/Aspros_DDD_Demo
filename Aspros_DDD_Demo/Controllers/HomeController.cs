using Microsoft.AspNetCore.Mvc;
using Aspros_DDD_Infrastructure.Utility.Filter;
using Microsoft.Extensions.Caching.Distributed;
using System;
using Aspros_DDD_Infrastructure.Caching;

namespace Aspros_DDD_Demo.Controllers
{
    //[StaticFileHandlerFilter]
    public class HomeController : Controller
    {
        //private IDistributedCache _memoryCache;

        private readonly RedisCacheService _cache;

      
        public IActionResult Index()
        {
            //var cacheKey = "key";
            //string result;
            //if(string.IsNullOrWhiteSpace(_memoryCache.GetString(cacheKey)))
            //{
            //    result = DateTime.Now.ToString();
            //    _memoryCache.SetString(cacheKey, result);
            //}
            var cacheKey = "key";
            if(_cache.Exists(cacheKey))
            {
                var cacheValue = _cache.Get<string>(cacheKey);
                return Content(cacheValue);
            }
            else
            {
                _cache.Add(cacheKey, DateTime.Now.ToString());
                return View();
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
