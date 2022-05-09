using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace XUnitTests.TestsHelper
{
    internal class TestApiApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();

            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<PostgresContext>));
                services.AddDbContext<PostgresContext>(options =>
                    options.UseInMemoryDatabase("Testing POSTGRES", root));

                services.RemoveAll(typeof(DbContextOptions<SqlServerContext>));
                services.AddDbContext<SqlServerContext>(options =>
                    options.UseInMemoryDatabase("Testing SQL", root));
            });

            return base.CreateHost(builder);
        }
    }
}