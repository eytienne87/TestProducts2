using API.Common;
using API.Dtos.Profiles;
using API.Middleware;
using API.Services.Abstractions;
using API.Services.Implementations;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var sqlConnectionString = builder.Configuration.GetConnectionString("SqlConnection");
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Add services to the container.
builder.Services.AddDbContext<SqlServerContext>(opt => opt.UseSqlServer(sqlConnectionString));
builder.Services.AddDbContext<PostgresContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection") ?? ""));
builder.Services.AddTransient<DataSeeder>();
//builder.Services.AddDbContext<SqlServerContext>(opt => opt.UseInMemoryDatabase("InMem"));
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddAutoMapper(typeof(BenefitsProfile));
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers().AddNewtonsoftJson(s => 
    s.SerializerSettings.ContractResolver = new DefaultContractResolver
    {
        NamingStrategy = new SnakeCaseNamingStrategy()
        //NamingStrategy = new CamelCaseNamingStrategy()
    }
);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ExceptionMiddleware>();


// Configure the HTTP request pipeline.
var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

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
    app.UseDeveloperExceptionPage();
}

app.MapControllers();
app.Run();

public partial class Program { }