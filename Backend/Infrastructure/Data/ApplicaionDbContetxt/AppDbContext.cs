using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data.ApplicaionDbContetxt;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }


    public DbSet<Banner> Banners { get; set; }
    public DbSet<Banner> Users { get; set; }
    public DbSet<Banner> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
