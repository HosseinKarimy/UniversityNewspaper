using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data.ApplicaionDbContetxt;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<GoodBanner> GoodBanners { get; set; }
    public DbSet<ServiceBanner> ServiceBanners { get; set; }
    public DbSet<EventBanner> EventBanners { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
