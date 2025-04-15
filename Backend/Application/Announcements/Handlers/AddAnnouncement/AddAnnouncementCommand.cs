using Application.Announcements.DTOs;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Announcements.Handlers.AddAnnouncement;

public record AddAnnouncementCommand(AddAnnouncementDto AnnouncementDto) : ICommand<AddAnnouncementResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

public record AddAnnouncementResult(Guid AnnouncementId);