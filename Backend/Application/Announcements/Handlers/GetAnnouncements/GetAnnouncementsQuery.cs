using Application.Announcements.DTOs;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Announcements.Handlers.GetAnnouncements;

public record GetAnnouncementsQuery : IQuery<GetAnnouncementsResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public record GetAnnouncementsResult(List<AnnouncementDto> Announcements);

