using Aspros_DDD_BootStrapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTest
{
    public class BaseTest
    { 
        protected readonly ITestOutputHelper Output;
        protected IServiceProvider Provider;

        public BaseTest(ITestOutputHelper output)
        {
            const string connectionString = @"server=10.9.25.67;database=aqhg_b2b;user id=root;password=EGm9PFzLbb!DSya.KH;persistsecurityinfo=True;AutoEnlist=false;";
            var service = new ServiceCollection();
            Output = output;
            service.Configure(connectionString);
            Provider = service.BuildServiceProvider();
        }
       
    }
}
