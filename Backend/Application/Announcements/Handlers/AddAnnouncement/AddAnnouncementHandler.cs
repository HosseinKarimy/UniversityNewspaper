using Application.Announcements.Repositories;
using Domain.Models;
using Domain.StronglyTypes;
using Helper.CQRS;

namespace Application.Announcements.Handlers.AddAnnouncement;

public class AddAnnouncementHandler(IAnnouncementUnitOfWork announcementUnitOfWork) : ICommandHandler<AddAnnouncementCommand, AddAnnouncementResult>
{
    public async Task<AddAnnouncementResult> Handle(AddAnnouncementCommand request, CancellationToken cancellationToken)
    {
        //create announcement model
        Announcement announcement = new()
        {
            Id = AnnouncementId.Of(Guid.NewGuid()),
            Title = request.AnnouncementDto.Title,
            Description = request.AnnouncementDto.Description,
            OwnerId = request.ContextCarrier.AuthenticatedUser.Id,
            CreatedAt = DateTime.Now,
        };

        //add to db
        var addedAnnouncement = await announcementUnitOfWork.AnnouncementRepository.AddAsync(announcement, cancellationToken);
        await announcementUnitOfWork.SaveChangesAsync(cancellationToken);

        //return to view
        return new AddAnnouncementResult(addedAnnouncement.Id.Value);
    }
}
