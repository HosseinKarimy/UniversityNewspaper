using Application.BazaarRepositories;
using Infrastructure.Data.ApplicaionDbContetxt;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayerServices(this IServiceCollection services)
    {
        services.AddScoped<IBannerRepository, BannerReopsitory>();
        services.AddDbContext<AppDbContext>(option => option.UseSqlite("Data Source=C:\\Users\\hossein\\source\\repos\\UniversityBazzar\\Backend\\Infrastructure\\Data\\ApplicaionDbContetxt\\Data.db"));
        return services;
    }
}
