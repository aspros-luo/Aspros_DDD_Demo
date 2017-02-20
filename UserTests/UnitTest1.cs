using Aspros_DDD_Domain_Repository_Interfaces.UserRepositoryInterfaces;
using System;
using Xunit;
using Xunit.Abstractions;
using XUnitTest;
using Microsoft.Extensions.DependencyInjection;
using Aspros_DDD_Domain_Repository_Interfaces.IdentityRepositoryInterfaces;

namespace UserTests
{
    public class UnitTest1 : BaseTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IIdentityRepository _identityRepository;
        public UnitTest1(ITestOutputHelper output) : base(output)
        {
            _userRepository = Provider.GetService<IUserRepository>();
            _identityRepository = Provider.GetService<IIdentityRepository>();
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
    }
}
