using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Framework.Infrastructure.Interfaces.Core;

namespace Aspros_DDD_Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;
        private IDbContextTransaction _dbContextTransaction;

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void BeginTransaction()
        {
            _dbContextTransaction = _dbContext.Database.BeginTransaction();
        }

        public async Task<bool> CommitAsync()
        {
            if (_dbContextTransaction == null)
                return await _dbContext.SaveChangesAsync() > 0;
            _dbContextTransaction.Commit();
            return true;
        }

        public async Task<bool> RegisterNew<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Add(entity);
            if (_dbContextTransaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public async Task<bool> RegisterClean<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Entry(entity).State = EntityState.Unchanged;
            if (_dbContextTransaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public async Task<bool> RegisterDeleted<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Remove(entity);
            if (_dbContextTransaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public async Task<bool> RegisterDirty<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            if (_dbContextTransaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }
        public async Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken = default(CancellationToken), params object[] parameters)
        {
            return await _dbContext.Database.ExecuteSqlCommandAsync(sql, cancellationToken, parameters);
        }

        public void Rollback()
        {
            _dbContextTransaction?.Rollback();
        }
    }
}
