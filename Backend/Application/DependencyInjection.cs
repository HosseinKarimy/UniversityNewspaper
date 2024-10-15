using FluentValidation;
using Helper.Mediator_Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayerServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(
            cfg =>
            {
                cfg.AddOpenRequestPreProcessor(typeof(AuthenticationBehavior<>))
                .AddOpenBehavior(typeof(ValidattionBehavior<,>))
                .RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
        return services;
    }
}
