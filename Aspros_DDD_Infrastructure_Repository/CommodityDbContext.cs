using System.Reflection;
using Aspros_DDD_Infrastructure;
using Framework.Infrastructure.Interfaces.Core;
using Microsoft.EntityFrameworkCore;

namespace Aspros_DDD_Infrastructure_Repository
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
