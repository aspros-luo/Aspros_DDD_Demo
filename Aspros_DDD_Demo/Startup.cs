using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Aspros_DDD_BootStrapping;
using System;
using Microsoft.Extensions.Options;
using Aspros_DDD_Infrastructure.Caching;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Caching.Memory;

namespace Aspros_DDD_Demo
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure(Configuration["data:ConnectionString"]);//添加数据库连接

            //services.AddMemoryCache();

            if(Convert.ToBoolean( Configuration["cache:UseRedis"]))
            {
                services.AddSingleton(typeof(ICacheService), new RedisCacheService(new RedisCacheOptions
                {
                    Configuration=Configuration["cache:Redis_ConnectionString"],
                    InstanceName=Configuration["cache:Redis_Instance"]
                },0));
            }
            else
            {
                services.AddSingleton<IMemoryCache>(factory =>
                {
                    var cache = new MemoryCache(new MemoryCacheOptions());
                    return cache;
                });
                services.AddSingleton<ICacheService, MemoryCacheService>();
            }

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Browser Link is not compatible with Kestrel 1.1.0
                // For details on enabling Browser Link, see https://go.microsoft.com/fwlink/?linkid=840936
                // app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
