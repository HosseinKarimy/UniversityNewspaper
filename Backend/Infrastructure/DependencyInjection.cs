using Application.Announcements.Repositories;
using Application.Bazaar.BazzarRepositories;
using Application.Events.EventsRepositories;
using Infrastructure.Data.ApplicaionDbContetxt;
using Infrastructure.Repositories;
using Infrastructure.Repositories.AnnouncementRepositories;
using Infrastructure.Repositories.BazaarRepositiories;
using Infrastructure.Repositories.EventsRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayerServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBazaarUnitOfWork, BazaarUnitOfWork>();
        services.AddScoped<IEventsUnitOfWork, EventsUnitOfWork>();
        services.AddScoped<IAnnouncementUnitOfWork, AnnouncementUnitOfWork>();
        var databasePath = "C:\\Users\\hossein\\source\\repos\\UniversityBazzar\\Backend\\Infrastructure\\Data\\DataBase\\Data.db";
        services.AddDbContext<AppDbContext>(option => option.UseSqlite($"Data Source = {databasePath}"));
        return services;
    }
}
