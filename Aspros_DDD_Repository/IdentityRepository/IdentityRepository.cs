using Aspros_DDD_Domain.IdentityItem;
using Aspros_DDD_Domain_Repository_Interfaces.IdentityRepositoryInterfaces;
using Framework.Infrastructure.Repository.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Infrastructure.Interfaces.Core;
using System.Linq;

namespace Aspros_DDD_Repository.IdentityRepository
{
    public class IdentityRepository : BaseRepository<Identity>, IIdentityRepository
    {
        public IdentityRepository(IDbContext dbContext) : base(dbContext)
        {

        }

        public Identity GetIdentityById(long id)
        {
            return _entities.SingleOrDefault(i => i.Id == id);
        }
    }
}
