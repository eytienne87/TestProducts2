using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API.DesignTime
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SqlServerContext>
    {
        public SqlServerContext CreateDbContext(string[] args)
        {
            // Ceci donne accès au fichier appsettings.json
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            configuration.SetBasePath(Directory.GetCurrentDirectory());
            configuration.AddJsonFile("appsettings.json");

            // Ensuite cela récupère le fichier appsettings.json pour le mettre dans le connectionstring 
            var connectionString = builder.Configuration.GetConnectionString("DesignTimeSqlServerTest");

            // Le contexte est configuré à l'aide des options fournies
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<SqlServerContext>();
            dbContextOptionsBuilder.UseSqlServer(connectionString);

            // Retourne le contexte configuré
            return new SqlServerContext(dbContextOptionsBuilder.Options);
        }
    }
}
