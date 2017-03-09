using Microsoft.AspNetCore.Mvc;
using Aspros_DDD_Infrastructure.Utility.Filter;
using Microsoft.Extensions.Caching.Distributed;
using System;

namespace Aspros_DDD_Demo.Controllers
{
    //[StaticFileHandlerFilter]
    public class HomeController : Controller
    {
        private IDistributedCache _memoryCache;

        public HomeController(IDistributedCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            var cacheKey = "key";
            string result;
            if(string.IsNullOrWhiteSpace(_memoryCache.GetString(cacheKey)))
            {
                result = DateTime.Now.ToString();
                _memoryCache.SetString(cacheKey, result);
            }
            return View();

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
