using Framework.Domain.Core;
using Framework.Infrastructure.Interfaces.Core;
using System.Linq;

namespace Framework.Infrastructure.Repository.Core
{
    public abstract class BaseRepository<TAggregateRoot> : IRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
    {
        public readonly IQueryable<TAggregateRoot> Entities;

        protected BaseRepository(IDbContext dbContext)
        {
            Entities = dbContext.Set<TAggregateRoot>();
        }

        public IQueryable<TAggregateRoot> GetAll()
        {
            return Entities;
        }
    }

}
