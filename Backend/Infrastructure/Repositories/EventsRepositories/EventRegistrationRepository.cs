using Application.Events.EventsRepositories;
using Domain.Models;
using Domain.StronglyTypes;
using Infrastructure.Data.ApplicaionDbContetxt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.EventsRepositories;

public class EventRegistrationRepository(AppDbContext dbContext) : Repository<EventRegistration, (EventId, UserId)>(dbContext.EventRegistrations), IEventRegistrationRepository
{
    public new async Task<EventRegistration?> GetByIdAsync((EventId , UserId) id, CancellationToken cancellationToken = default)
    {
        return await dbContext.EventRegistrations.Include(er=>er.User).Include(er => er.User).FirstOrDefaultAsync(
            x => x.EventId == id.Item1 && x.UserId == id.Item2, cancellationToken);
    }

    public async Task<List<EventRegistration>> GetRegistrationsOfEvent(EventId eventId, CancellationToken cancellationToken = default)
    {
        return await dbContext.EventRegistrations.Where(er => er.EventId == eventId).ToListAsync(cancellationToken);
    }
}
