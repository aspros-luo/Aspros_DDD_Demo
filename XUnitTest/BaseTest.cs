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
            //const string connectionString = @"server=.;database=tets;user id=root;password=123;persistsecurityinfo=True;AutoEnlist=false;";
            const string connectionString = @"Data Source = localhost; Initial Catalog = CoreDb; Integrated Security = False; Persist Security Info = False; User ID = sa; Password = 123456";
            var service = new ServiceCollection();
            Output = output;
            service.Configure(connectionString);
            Provider = service.BuildServiceProvider();
        }

    }
}
