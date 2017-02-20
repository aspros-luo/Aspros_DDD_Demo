using Aspros_DDD_Domain_Repository_Interfaces.UserRepositoryInterfaces;
using Aspros_DDD_Infrastructure;
using Aspros_DDD_Repository.UserRepositories;
using Framework.Infrastructure.Interfaces.Core;
using Microsoft.Extensions.DependencyInjection;
using MySQL.Data.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Aspros_DDD_Domain_Repository_Interfaces.IdentityRepositoryInterfaces;
using Aspros_DDD_Repository.IdentityRepository;

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

            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<IIdentityRepository, IdentityRepository>();
        }
    }
}
