using System.Linq;

namespace Framework.Domain.Core
{
    public interface IRepository<out TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
    {
        IQueryable<TAggregateRoot> GetAll();
    }
}
