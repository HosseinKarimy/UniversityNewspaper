using Application.Events.DTOs;
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
        return await dbContext.Events.Include(e => e.Registrations).ToListAsync(cancellationToken);
    }

    public new async Task<Event?> GetByIdAsync(EventId id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Events.Include(e => e.Registrations).FirstAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<List<Event>> GetEventsCreatedByUser(UserId userId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Events.Where(e=>e.OwnerId == userId).Include(e => e.Registrations).ToListAsync(cancellationToken);
    }

    public async Task<List<Event>> GetEventsRegisteredByUser(UserId userId, CancellationToken cancellationToken = default)
    {
         return await dbContext.Events.Where(e=>e.Registrations.Any(u=>u.UserId == userId)).Include(e => e.Registrations).ToListAsync(cancellationToken);
    }

    public async Task<List<Event>> GetFilteredEvents(EventSearchFilter Filters, CancellationToken cancellationToken = default)
    {
        var dbQuery = dbContext.Events
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(Filters.Title))
            dbQuery = dbQuery.Where(e => e.Title.Contains(Filters.Title));

        if (Filters.OwnerId.HasValue)
            dbQuery = dbQuery.Where(e => e.OwnerId == UserId.Of(Filters.OwnerId.Value));

        if (Filters.Status.HasValue)
            dbQuery = dbQuery.Where(e => e.EventStatus == Filters.Status.Value);

        //if (Filters.FromDate.HasValue)
        //    dbQuery = dbQuery.Where(e => e.Date >= Filters.FromDate.Value);

        //if (Filters.ToDate.HasValue)
        //    dbQuery = dbQuery.Where(e => e.Date <= Filters.ToDate.Value);

        //if (Filters.DepartmentId.HasValue)
        //    dbQuery = dbQuery.Where(e => e.Organizers.Any(o => o.Id == Filters.DepartmentId.Value));

        //var totalCount = await dbQuery.CountAsync(cancellationToken);

        return await dbQuery
            .OrderByDescending(e => e.Date)
            .Skip((Filters.Page - 1) * Filters.PageSize)
            .Take(Filters.PageSize)           
            .ToListAsync(cancellationToken);
    }
}
