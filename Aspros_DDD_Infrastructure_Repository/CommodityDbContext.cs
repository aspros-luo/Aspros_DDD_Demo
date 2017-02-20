using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Framework.Infrastructure.Interfaces.Core;

namespace Aspros_DDD_Infrastructure
{
    public class CommodityDbContext : DbContext, IDbContext
    {
        public CommodityDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddEntityConfigurationsFromAssembly(GetType().GetTypeInfo().Assembly);
        }
    }
}
