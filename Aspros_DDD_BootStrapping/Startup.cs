using Aspros_DDD_Infrastructure;
using Framework.Infrastructure.Interfaces.Core;
using Microsoft.Extensions.DependencyInjection;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace Aspros_DDD_BootStrapping
{
    public static class Startup
    {
        public static void Configure(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<CommodityDbContext>(optionsBuilder => optionsBuilder.UseMySQL(connectionString));

            service.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
