namespace Application.Events.EventsRepositories;

public interface IEventsUnitOfWork
{
    public IEventsRepository EventsRepository { get; }
    public IEventRegistrationRepository EventRegisterationRepository { get; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
