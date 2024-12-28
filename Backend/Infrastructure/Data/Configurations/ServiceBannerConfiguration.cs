using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class ServiceBannerConfiguration : IEntityTypeConfiguration<ServiceBanner>
{
    public void Configure(EntityTypeBuilder<ServiceBanner> builder)
    {
        builder.Property(b=>b.ServiceType).IsRequired(false);
    }
}
