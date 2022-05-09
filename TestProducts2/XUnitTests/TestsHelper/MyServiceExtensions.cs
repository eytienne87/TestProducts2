using API.Middleware;
using Microsoft.Extensions.DependencyInjection;

public static class MyServiceExtensions
{
    public static void AddMyServices(
           this IServiceCollection services)
    {
        services.AddTransient<ExceptionMiddleware>();
    }
}