using Application.Events.EventsRepositories;
using Domain.Models;
using Domain.StronglyTypes;
using Infrastructure.Data.ApplicaionDbContetxt;

namespace Infrastructure.Repositories.EventsRepositories;

public class EventsRepositories(AppDbContext dbContext) : Repository<Event, EventId>(dbContext.Events), IEventsRepository
{

    public new async Task<Event?> GetByIdAsync(EventId id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Events.Include(e => e.RegisteredUsers).FirstAsync(e => e.Id == id, cancellationToken);
    }
}
