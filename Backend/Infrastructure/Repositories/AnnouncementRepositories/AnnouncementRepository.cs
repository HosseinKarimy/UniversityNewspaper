using Application.Announcements.Repositories;
using Domain.Models;
using Domain.StronglyTypes;
using Infrastructure.Data.ApplicaionDbContetxt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.AnnouncementRepositories;

public class AnnouncementRepository(AppDbContext dbContext) : Repository<Announcement, AnnouncementId>(dbContext.Announcements), IAnnouncementRepository
{
    public Task<List<Announcement>> GetAnnouncementsCreatedByUser(UserId userId, CancellationToken cancellationToken = default)
    {
        return dbContext.Announcements.Where(a => a.OwnerId == userId).ToListAsync(cancellationToken);
    }
}
