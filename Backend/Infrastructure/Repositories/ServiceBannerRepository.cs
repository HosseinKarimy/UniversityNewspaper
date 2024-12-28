using Application.Bazaar.BazzarRepositories;
using Domain.Models;
using Infrastructure.Data.ApplicaionDbContetxt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ServiceBannerRepository(AppDbContext dbContext) : Repository<ServiceBanner , Guid>(dbContext.ServiceBanners) , IServiceBannerRepository
{
}
