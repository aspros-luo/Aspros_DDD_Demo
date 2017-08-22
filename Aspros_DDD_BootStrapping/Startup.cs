using Aspros_DDD_Application.IdentityServices;
using Aspros_DDD_Application_Interfaces.IdentityServiceInterfaces;
using Aspros_DDD_Domain_Repository_Interfaces.IdentityRepositoryInterfaces;
using Aspros_DDD_Infrastructure_Repository;
using Aspros_DDD_Repository.IdentityRepository;
using Framework.Infrastructure.Core;
using Framework.Infrastructure.Interfaces.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Aspros_DDD_BootStrapping
{
    public static class Startup
    {
        public static void Configure(this IServiceCollection service, string connectionString)
        {
            service.AddEntityFrameworkSqlServer().AddDbContext<CommodityDbContext>(options => options.UseSqlServer(connectionString));

            //service.AddDbContext<CommodityDbContext>(options =>options.UseMySQL(connectionString));

            service.AddTransient<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IDbContext, CommodityDbContext>();
            service.AddSingleton<IWorkContext, WorkContext>();

            service.AddTransient<IIdentityRepository, IdentityRepository>();
            service.AddTransient<IIdentityService, IdentityService>();
        }
    }
}
