using Application.Announcements.DTOs;
using Application.Announcements.Repositories;
using Helper.CQRS;

namespace Application.Announcements.Handlers.GetAnnouncements;

public class GetAnnouncementsHandler(IAnnouncementUnitOfWork announcementUnitOfWork) : IQueryHandler<GetAnnouncementsQuery, GetAnnouncementsResult>
{
    public async Task<GetAnnouncementsResult> Handle(GetAnnouncementsQuery request, CancellationToken cancellationToken)
    {
        var announcements = await announcementUnitOfWork.AnnouncementRepository.GetAllAsync(cancellationToken);
        var announcementsDtos = announcements.Select(a => AnnouncementDto.FromAnnouncement(a)).ToList();
        return new GetAnnouncementsResult(announcementsDtos);
    }
}
