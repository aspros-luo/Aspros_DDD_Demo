using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Infrastructure.Interfaces.Core
{
    public interface IUnitOfWork
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        IDbTransaction BeginTransaction();
     
        Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken = default(CancellationToken), params object[] parameters);
        Task<bool> RegisterClean<TEntity>(TEntity entity) where TEntity : class;
        Task<bool> RegisterNew<TEntity>(TEntity entity) where TEntity : class;
        Task<bool> RegisterDirty<TEntity>(TEntity entity) where TEntity : class;
        Task<bool> RegisterDeleted<TEntity>(TEntity entity) where TEntity : class;
        Task<bool> RegisterRangeDeleted<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class;
        Task<bool> CommitAsync();
        void Rollback();
    }
}
