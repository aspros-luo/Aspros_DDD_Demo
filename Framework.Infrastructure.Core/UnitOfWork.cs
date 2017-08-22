using Framework.Infrastructure.Interfaces.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Infrastructure.Core
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly IDbContext _dbContext;

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IDbConnection Connection => _dbContext.Database.GetDbConnection();
        public IDbTransaction Transaction { get; set; }
        public IDbTransaction BeginTransaction()
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            return Transaction = Connection.BeginTransaction();
        }

        public async Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken = new CancellationToken(),
            params object[] parameters)
        {
            return await _dbContext.Database.ExecuteSqlCommandAsync(sql, cancellationToken, parameters);
        }

        public async Task<bool> RegisterNew<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Add(entity);
            if (Transaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }
        public async Task<bool> RegisterDirty<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            if (Transaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public async Task<bool> RegisterClean<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Entry(entity).State = EntityState.Unchanged;
            if (Transaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public async Task<bool> RegisterDeleted<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Remove(entity);
            if (Transaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public async Task<bool> RegisterRangeDeleted<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
            if (Transaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public async Task<bool> CommitAsync()
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            if (Transaction == null) return await _dbContext.SaveChangesAsync() > 0;
            Transaction.Commit();
            return true;
        }

        public void Rollback()
        {
            Transaction?.Rollback();
        }
    }
}
