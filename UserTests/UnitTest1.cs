using Aspros_DDD_Domain_Repository_Interfaces.UserRepositoryInterfaces;
using System;
using Xunit;
using Xunit.Abstractions;
using XUnitTest;
using Microsoft.Extensions.DependencyInjection;
using Aspros_DDD_Domain_Repository_Interfaces.IdentityRepositoryInterfaces;
using Aspros_DDD_Application_Interfaces.IdentityServiceInterfaces;
using Aspros_DDD_Domain.IdentityItem;
using System.Threading.Tasks;

namespace UserTests
{
    public class UnitTest1 : BaseTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IIdentityRepository _identityRepository;
        private readonly IIdentityService _identityService;
        public UnitTest1(ITestOutputHelper output) : base(output)
        {
            _userRepository = Provider.GetService<IUserRepository>();
            _identityRepository = Provider.GetService<IIdentityRepository>();
            _identityService = Provider.GetService<IIdentityService>();
        }

        [Fact]
        public void Test1()
        {
            var user = _userRepository.GetUserById(56);
            Console.Write(user);
        }

        [Fact]
        public void Test2()
        {
            var identity = _identityRepository.GetIdentityById(1);
            Console.Write(identity);
        }

        [Fact]
        public async Task Test3()
        {
            var identity = new Identity { Id = 3, Name = "Q" };
            var result = await _identityService.Delete(identity);
        }
    }
}
