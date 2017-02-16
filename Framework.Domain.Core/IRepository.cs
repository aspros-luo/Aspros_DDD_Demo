using System.Linq;

namespace Framework.Domain.Core
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
    {
        IQueryable<TAggregateRoot> Get(long id);
        IQueryable<TAggregateRoot> GetAll();
    }
}
