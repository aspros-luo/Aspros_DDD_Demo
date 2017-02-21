using Aspros_DDD_Application_Interfaces.IdentityServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Aspros_DDD_Domain.IdentityItem;
using System.Threading.Tasks;
using Framework.Infrastructure.Interfaces.Core;
using Aspros_DDD_Domain_Repository_Interfaces.IdentityRepositoryInterfaces;

namespace Aspros_DDD_Application.IdentityServices
{
    public class IdentityService : IIdentityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIdentityRepository _identityRepository;

        public IdentityService(IUnitOfWork unitOfWork, IIdentityRepository identityRepository)
        {
            _unitOfWork = unitOfWork;
            _identityRepository = identityRepository;
        }

        public async Task<bool> Add(Identity identity)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                await _unitOfWork.RegisterNew(identity);
                return await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public async Task<bool> Delete(Identity identity)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                await _unitOfWork.RegisterDeleted(identity);
                return await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public Task<List<Identity>> GetIdentituByIds(List<long> ids)
        {
            throw new NotImplementedException();
        }

        public Task<Identity> GetIdentityById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Identity identity)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                await _unitOfWork.RegisterDirty(identity);
                return await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
