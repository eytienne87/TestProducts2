using API.Common;
using API.Middleware;
using API.Services.Abstractions;
using API.Services.Implementations;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace XUnitTests.TestsHelper
{
    internal class TestHelper
    {
        private readonly SqlServerContext _context;
        public IServiceManager ServiceManager { get; set; }

        public TestHelper()
        {
            var builder = new DbContextOptionsBuilder<SqlServerContext>();
            builder.UseInMemoryDatabase(databaseName: "TestDbInMemory");
            var dbContextOptions = builder.Options;
            
            _context = new SqlServerContext(dbContextOptions);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            ServiceManager = GetServiceManager();
        }

        public IRepositoryManager GetInMemoryRepository()
        {
            return new RepositoryManager(_context);
        }
        public IMapper GetMapper()
        {
            return new MapperConfiguration(mc =>
            {
                mc.AddMaps(Assembly.Load("API"));
            }).CreateMapper();
        }
        public IServiceManager GetServiceManager()
        {
            return new ServiceManager(GetInMemoryRepository(), GetMapper());
        }

        public void TestSeedData()
        {
            var seeder = new DataSeeder(_context, null);
            seeder.Seed();
        }
    }
}