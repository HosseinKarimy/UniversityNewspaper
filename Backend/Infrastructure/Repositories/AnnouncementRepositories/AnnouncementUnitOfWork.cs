using Application.Announcements.Repositories;
using Application.Events.EventsRepositories;
using Infrastructure.Data.ApplicaionDbContetxt;
using System;

namespace Infrastructure.Repositories.AnnouncementRepositories;

public class AnnouncementUnitOfWork(AppDbContext appDbContext) : IAnnouncementUnitOfWork
{
    private readonly IAnnouncementRepository _AnnouncementRepository = new AnnouncementRepository(appDbContext);

    public IAnnouncementRepository AnnouncementRepository => _AnnouncementRepository;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await appDbContext.SaveChangesAsync(cancellationToken);
    }
}

