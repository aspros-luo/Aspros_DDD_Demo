using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aspros_DDD_Infrastructure.Config
{
    public abstract class ConfigInfo
    {
        public abstract string SectionName { get; }
        public abstract void RegisterOptions(IServiceCollection services, IConfigurationRoot root);
    }
}
