using Application.Announcements.Repositories;
using Domain.Models;
using Domain.StronglyTypes;
using Infrastructure.Data.ApplicaionDbContetxt;

namespace Infrastructure.Repositories.AnnouncementRepositories;

public class AnnouncementRepository(AppDbContext dbContext) : Repository<Announcement,AnnouncementId>(dbContext.Announcements),IAnnouncementRepository
{
}
