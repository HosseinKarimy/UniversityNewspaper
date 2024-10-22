using Application.Bazaar.BazzarRepositories;
using Infrastructure.Data.ApplicaionDbContetxt;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayerServices(this IServiceCollection services)
    {
        services.AddScoped<IBannerRepository, BannerRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        var databasePath = "C:\\Users\\hossein\\source\\repos\\UniversityBazzar\\Backend\\Infrastructure\\Data\\DataBase\\Data.db";
        services.AddDbContext<AppDbContext>(option => option.UseSqlite($"Data Source = {databasePath}"));
        return services;
    }
}
