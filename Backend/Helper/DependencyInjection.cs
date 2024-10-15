using Microsoft.Extensions.DependencyInjection;

namespace Helper;

public static class DependencyInjection
{
    public static IServiceCollection AddHelperServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        return services;
    }
}
