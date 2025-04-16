using Application.Announcements.DTOs;
using Application.Announcements.Handlers.GetAnnouncements;
using Application.Announcements.Repositories;
using Application.Mediator_Pipeline;
using Helper.CQRS;

namespace Application.Announcements.Handlers.GetAnnouncementsCreatedByUser;

public class GetAnnouncementsCreatedByUserHandler(IAnnouncementUnitOfWork announcementUnitOfWork) : IQueryHandler<GetAnnouncementsCreatedByUserQuery, GetAnnouncementsResult>
{
    public async Task<GetAnnouncementsResult> Handle(GetAnnouncementsCreatedByUserQuery request, CancellationToken cancellationToken)
    {
        Authorization();
        var announcements = await announcementUnitOfWork.AnnouncementRepository.GetAnnouncementsCreatedByUser(request.UserId ,cancellationToken);
        var announcementsDtos = announcements.Select(a => AnnouncementDto.FromAnnouncement(a)).ToList();
        return new GetAnnouncementsResult(announcementsDtos);

        void Authorization()
        {
            if (request.ContextCarrier.AuthenticatedUser.Id != request.UserId)
                throw new Exception("Unauthorized");
        }
    }

}
