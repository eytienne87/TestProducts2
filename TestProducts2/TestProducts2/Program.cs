using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using TestProducts2.Common;
using TestProducts2.Services.Abstractions;
using TestProducts2.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

//var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Add services to the container.
//builder.Services.AddDbContext<SqlServerContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddTransient<DataSeeder>();
//builder.Services.AddDbContext<SqlServerContext>(opt => opt.UseInMemoryDatabase("InMem"));
builder.Services.AddDbContext<SqlServerContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection") ?? ""));
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers().AddNewtonsoftJson(s => 
    s.SerializerSettings.ContractResolver = new DefaultContractResolver
    {
        NamingStrategy = new SnakeCaseNamingStrategy()
        //NamingStrategy = new CamelCaseNamingStrategy()
    }
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the HTTP request pipeline.
var app = builder.Build();

//Seed
//if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory!.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service!.Seed();
    }
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
