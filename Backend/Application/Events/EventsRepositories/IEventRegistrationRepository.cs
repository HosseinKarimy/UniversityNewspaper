using Application.Bazaar.BazzarRepositories;
using Domain.Models;
using Domain.StronglyTypes;

namespace Application.Events.EventsRepositories;

public interface IEventRegistrationRepository : IRepository<EventRegistration , (EventId, UserId)>
{

}
