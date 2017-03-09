using Aspros_DDD_Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aspros_DDD_Infrastructure.Caching
{
    public sealed class CachingConfigInfo : ConfigInfo
    {
        public int DefaultSlidingTime { get; set; }
        public String Type { get; set; }

        public List<CacheServer> Servers { get; set; }

        public override string SectionName => "MicroStrutLibrary:Caching";

        public override void RegisterOptions(IServiceCollection services, IConfigurationRoot root)
        {
            var a = root.GetSection(SectionName);
            services.Configure<CachingConfigInfo>(root.GetSection(SectionName));
        }
    }
}
