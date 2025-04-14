using Application.Bazaar.BazzarRepositories;
using Domain.Models;
using Domain.StronglyTypes;

namespace Application.Events.EventsRepositories
{
    public interface IEventsRepository : IRepository<Event,EventId>
    {
        public Task<List<Event>> GetEventsCreatedByUser(UserId userId,CancellationToken cancellationToken = default);
        public Task<List<Event>> GetEventsRegisteredByUser(UserId userId, CancellationToken cancellationToken = default);
    }
}
