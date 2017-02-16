using System;
using System.Linq;
using System.Collections.Generic;
using Aspros_DDD_Domain.UserItem;
using Framework.Infrastructure.Repository.Core;
using Aspros_DDD_Domain_Repository_Interfaces.UserRepositoryInterfaces;
using Framework.Infrastructure.Interfaces.Core;

namespace Aspros_DDD_Repository.UserRepositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IDbContext dbContext) : base(dbContext)
        {

        }

        public User GetUserById(long id)
        {
            return _entities.SingleOrDefault(u => u.UserId == id);
        }

        public IQueryable<User> GetUserByIds(List<long> ids)
        {
            return _entities.Where(u => ids.Contains(u.UserId));
        }

        public Tuple<bool, User, string> Verify(string loginName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
