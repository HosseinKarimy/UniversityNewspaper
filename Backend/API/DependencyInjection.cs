using Carter;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

namespace API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiLayerServices(this IServiceCollection services)
    {        
        services.AddCarter();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));        
        services.AddExceptionHandler<GlobalExceptionHandler>();
        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.MapCarter();

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads")),
            RequestPath = "/uploads"
        });

        app.UseExceptionHandler(opt => { });

        MapsterConfiguration.MapsterConfigurations();
        return app;
    }
}
