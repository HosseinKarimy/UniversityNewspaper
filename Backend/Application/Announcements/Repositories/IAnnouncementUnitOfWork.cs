namespace Application.Announcements.Repositories;

public interface IAnnouncementUnitOfWork
{
    public IAnnouncementRepository AnnouncementRepository { get; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
