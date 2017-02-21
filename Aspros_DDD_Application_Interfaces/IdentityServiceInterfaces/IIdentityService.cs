using Aspros_DDD_Domain.IdentityItem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aspros_DDD_Application_Interfaces.IdentityServiceInterfaces
{
    public interface IIdentityService
    {
        Task<bool> Add(Identity identity);
        Task<bool> Update(Identity identity);
        Task<bool> Delete(Identity identity);

        Task<Identity> GetIdentityById(long id);
        Task<List<Identity>> GetIdentituByIds(List<long> ids);
    }
}
