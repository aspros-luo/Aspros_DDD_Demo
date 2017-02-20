using Aspros_DDD_Domain.IdentityItem;
using Framework.Domain.Core;

namespace Aspros_DDD_Domain_Repository_Interfaces.IdentityRepositoryInterfaces
{
    public interface IIdentityRepository : IRepository<Identity>
    {
        Identity GetIdentityById(long id);
    }
}
