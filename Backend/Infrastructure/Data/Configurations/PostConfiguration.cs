using Domain.Models;
using Domain.StronglyTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class PostConfiguration<TId> : IEntityTypeConfiguration<Post<TId>>
{
    public void Configure(EntityTypeBuilder<Post<TId>> builder)
    {
        
    }
}
