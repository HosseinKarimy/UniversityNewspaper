using Application.Events.EventsRepositories;
using Domain.Models;
using Domain.StronglyTypes;
using Infrastructure.Data.ApplicaionDbContetxt;

namespace Infrastructure.Repositories.EventsRepositories;

public class EventsRepositories(AppDbContext dbContext) : Repository<Event, EventId>(dbContext.Events), IEventsRepository
{
}
