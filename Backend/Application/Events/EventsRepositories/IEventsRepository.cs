using Application.Bazaar.BazzarRepositories;
using Domain.Models;
using Domain.StronglyTypes;

namespace Application.Events.EventsRepositories
{
    public interface IEventsRepository : IRepository<Event,EventId>
    {

    }
}
