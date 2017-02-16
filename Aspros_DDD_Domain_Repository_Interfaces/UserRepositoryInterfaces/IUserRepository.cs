using System;
using System.Linq;
using Framework.Domain.Core;
using System.Collections.Generic;
using Aspros_DDD_Domain.UserItem;

namespace Aspros_DDD_Domain_Repository_Interfaces.UserRepositoryInterfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IQueryable<User> GetUserByIds(List<long> ids);

        User GetUserById(long id);

        Tuple<bool, User, string> Verify(string loginName, string password);
    }
}
