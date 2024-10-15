using Carter;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Reflection;

namespace API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiLayerServices(this IServiceCollection services)
    {
        
        services.AddCarter();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.MapCarter();

        MapsterConfiguration.MapsterConfigurations();
        return app;
    }
}
