using Application.Events.EventsRepositories;
using Infrastructure.Data.ApplicaionDbContetxt;
using System;

namespace Infrastructure.Repositories.EventsRepositories;

public class EventsUnitOfWork(AppDbContext appDbContext) : IEventsUnitOfWork
{
    private readonly IEventsRepository _EventsRepository = new EventsRepositories(appDbContext);

    public IEventsRepository EventsRepository => _EventsRepository;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await appDbContext.SaveChangesAsync(cancellationToken);
    }
}
