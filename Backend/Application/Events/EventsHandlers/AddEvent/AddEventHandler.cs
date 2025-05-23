﻿using Application.Events.DTOs;
using Application.Events.EventsRepositories;
using Application.Exceptions;
using Domain.Models;
using Domain.StronglyTypes;
using Helper.CQRS;


namespace Application.Events.EventsHandlers.AddEvent;

public class AddEventHandler(IEventsUnitOfWork eventsUnitOfWork) : ICommandHandler<AddEventCommand, RequestResult<Guid>>
{
    public async Task<RequestResult<Guid>> Handle(AddEventCommand request, CancellationToken cancellationToken)
    {
        Authorization();

        var newEvent = CreateNewEvent(request.EventDto, request.ContextCarrier.AuthenticatedUser!.Id.Value);
        var createEvent = await eventsUnitOfWork.EventsRepository.AddAsync(newEvent, cancellationToken);
        await eventsUnitOfWork.SaveChangesAsync(cancellationToken);
        return new RequestResult<Guid>(createEvent.Id.Value , true , "Event Added Successfuly");

        static Event CreateNewEvent(AddOrUpdateEventDto eventDto, int userId)
        {
            return new Event()
            {
                Id = EventId.Of(Guid.NewGuid()),
                Title = eventDto.Title,
                Description = eventDto.Description,
                AdditionalInfoPairs = eventDto.AdditionalInfoPairs,
                Date = eventDto.Date,
                ImageUrl = eventDto.ImageURl,
                Location = eventDto.Location,
                Organizers = eventDto.Organizers,
                OwnerId = UserId.Of(userId),
                CreatedAt = DateTime.Now,
                Deadline = eventDto.Deadline,
                Capacity = eventDto.Capacity,
                Fee = eventDto.Fee,
                EventStatus = eventDto.Status
            };
        }

        void Authorization()
        {
            if (request.ContextCarrier.AuthenticatedUser!.CanAddEvent is false)
            {
                throw new AccessDeniedExcepion("Access Denied for Adding Event");
            }
        }
    }

}
