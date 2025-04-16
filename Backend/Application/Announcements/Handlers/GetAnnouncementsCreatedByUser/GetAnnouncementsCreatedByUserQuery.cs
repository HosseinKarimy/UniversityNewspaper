using Application.Announcements.Handlers.GetAnnouncements;
using Domain.StronglyTypes;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Announcements.Handlers.GetAnnouncementsCreatedByUser;

public record GetAnnouncementsCreatedByUserQuery(UserId UserId) : IQuery<GetAnnouncementsResult>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}
