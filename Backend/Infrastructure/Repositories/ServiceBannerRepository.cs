using Application.Bazaar.BazzarRepositories;
using Domain.Models;
using Infrastructure.Data.ApplicaionDbContetxt;

namespace Infrastructure.Repositories;

public class ServiceBannerRepository(AppDbContext dbContext) : BannerRepository<ServiceBanner>(dbContext.ServiceBanners) , IServiceBannerRepository
{
}
