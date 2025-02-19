using Application.Bazaar.BazzarRepositories;
using Domain.Models;

namespace Application.Events.EventsRepositories
{
    public interface IEventsRepository : IRepository<Event,Guid>
    {
    }
}
