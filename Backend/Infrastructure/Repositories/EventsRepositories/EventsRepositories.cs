using Application.Events.EventsRepositories;
using Domain.Models;
using Infrastructure.Data.ApplicaionDbContetxt;

namespace Infrastructure.Repositories.EventsRepositories;

public class EventsRepositories(AppDbContext dbContext) : Repository<Event, Guid>(dbContext.Events), IEventsRepository
{
}
