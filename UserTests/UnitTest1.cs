using Aspros_DDD_Domain_Repository_Interfaces.UserRepositoryInterfaces;
using System;
using Xunit;
using Xunit.Abstractions;
using XUnitTest;
using Microsoft.Extensions.DependencyInjection;

namespace UserTests
{
    public class UnitTest1 : BaseTest
    { 
        private readonly IUserRepository _userRepository;
        public UnitTest1(ITestOutputHelper output) : base(output)
        {
            _userRepository = Provider.GetService<IUserRepository>();
        }

        [Fact]
        public void Test1()
        {
            var user = _userRepository.GetUserById(56);
            Console.Write(user);
        }
    }
}
