using System;
using System.Linq;
using Framework.Domain.Core;
using Framework.Infrastructure.Interfaces.Core;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Framework.Infrastructure.Repository.Core
{
    public abstract class BaseRepository<TAggregateRoot> : IRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
    {
        public readonly IQueryable<TAggregateRoot> _entities;
        public BaseRepository(IDbContext dbContext)
        {
            _entities = dbContext.Set<TAggregateRoot>();
        }

        public IQueryable<TAggregateRoot> Get(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TAggregateRoot> GetAll()
        {
            return _entities;
        }
    }
    
}
