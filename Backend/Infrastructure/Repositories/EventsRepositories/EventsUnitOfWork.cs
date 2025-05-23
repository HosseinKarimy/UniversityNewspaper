﻿using Application.Events.EventsRepositories;
using Infrastructure.Data.ApplicaionDbContetxt;
using System;

namespace Infrastructure.Repositories.EventsRepositories;

public class EventsUnitOfWork(AppDbContext appDbContext) : IEventsUnitOfWork
{
    private readonly IEventsRepository _EventsRepository = new EventsRepositories(appDbContext);
    private readonly IEventRegistrationRepository _EventRegistrationRepository = new EventRegistrationRepository(appDbContext);

    public IEventsRepository EventsRepository => _EventsRepository;

    public IEventRegistrationRepository EventRegisterationRepository => _EventRegistrationRepository;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await appDbContext.SaveChangesAsync(cancellationToken);
    }
}
