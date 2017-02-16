using System.Threading;
using System.Threading.Tasks;

namespace Framework.Infrastructure.Interfaces.Core
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        Task<bool> CommitAsync();
        Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken = default(CancellationToken), params object[] parameters);
        Task<bool> RegisterClean<TEntity>(TEntity entity) where TEntity : class;
        Task<bool> RegisterDeleted<TEntity>(TEntity entity) where TEntity : class;
        Task<bool> RegisterDirty<TEntity>(TEntity entity) where TEntity : class;
        Task<bool> RegisterNew<TEntity>(TEntity entity) where TEntity : class;
        void Rollback();
    }
}
