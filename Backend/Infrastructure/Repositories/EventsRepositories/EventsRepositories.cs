using Application.Events.EventsRepositories;
using Domain.Models;
using Domain.StronglyTypes;
using Infrastructure.Data.ApplicaionDbContetxt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.EventsRepositories;

public class EventsRepositories(AppDbContext dbContext) : Repository<Event, EventId>(dbContext.Events), IEventsRepository
{

    public new async Task<List<Event>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Events.Include(e=>e.RegisteredUsers).ToListAsync(cancellationToken);
    }

    public new async Task<Event?> GetByIdAsync(EventId id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Events.Include(e => e.RegisteredUsers).FirstAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<List<Event>> GetByUserId(UserId userId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Events.Where(e=>e.OwnerId == userId).Include(e => e.RegisteredUsers).ToListAsync(cancellationToken);
    }

    public async Task<List<Event>> GetEventsRegisteredByUser(UserId userId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Events.Where(e=>e.RegisteredUsers.Any(u=>u.Id == userId)).Include(e => e.RegisteredUsers).ToListAsync(cancellationToken);
    }
}
