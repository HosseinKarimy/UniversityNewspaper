using Domain.Models;

namespace Application.Announcements.DTOs;

public record AnnouncementDto(
    Guid Id,
    string Title,
    string? Description,
    int OwnerId,
    DateTime CreatedAt)
{
    public static AnnouncementDto FromAnnouncement(Announcement announcement)
    {
        return new AnnouncementDto(
            announcement.Id.Value,
            announcement.Title,
            announcement.Description,
            announcement.OwnerId.Value,
            announcement.CreatedAt);
    }
}
