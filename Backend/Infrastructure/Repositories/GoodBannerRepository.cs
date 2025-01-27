using Application.Bazaar.BazzarRepositories;
using Domain.Models;
using Infrastructure.Data.ApplicaionDbContetxt;

namespace Infrastructure.Repositories;

public class GoodBannerRepository(AppDbContext dbContext) : BannerRepository<GoodBanner>(dbContext.GoodBanners), IGoodBannerRepository
{

}
