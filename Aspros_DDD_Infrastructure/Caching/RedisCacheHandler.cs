using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using System.Linq;

namespace Aspros_DDD_Infrastructure.Caching
{
    public class RedisCacheHandler : BaseCacheHandler
    {
        private IDistributedCache _redisCache;
        public RedisCacheHandler(CachingConfigInfo configInfo) : base(configInfo)
        {
            IOptions<RedisCacheOptions> optionsAccessor = new RedisCacheOptions();
            optionsAccessor.Value.Configuration = string.Join(",", _ConfigInfo.Servers.Select(s => s.HostName + ":" + s.Port));
            optionsAccessor.Value.InstanceName = "Runtime";

            _redisCache = new RedisCache(optionsAccessor);
        }

        protected override IDistributedCache _Cache => _redisCache;
    }
}
