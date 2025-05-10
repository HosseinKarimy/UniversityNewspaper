using Application.Bazaar.BazzarRepositories;
using Application.Events.EventsRepositories;
using Application.Exceptions;
using Application.Users.DTO;
using Application.Users.Repositroies;
using Helper.CQRS;

namespace Application.Users.Handlers.GetUserStatus;

public class GetUserStatusHandler(IUserRepository userRepository, IBazaarUnitOfWork bazaarUnitOfWork , IEventsUnitOfWork eventsUnitOfWork) : IQueryHandler<GetUserStatusQuery, UserStatusDto>
{
    public async Task<UserStatusDto> Handle(GetUserStatusQuery request, CancellationToken cancellationToken)
    {
        Authorization();
        var user = await userRepository.GetByIdAsync(request.UserId, cancellationToken) ?? throw new Exception("User Not Found");
        var banners = await bazaarUnitOfWork.BannerRepository.GetBannersCreatedByUser(request.UserId, cancellationToken);
        var events = await eventsUnitOfWork.EventsRepository.GetEventsCreatedByUser(request.UserId, cancellationToken);

        return new UserStatusDto(user!.Id.Value, banners.Count, events.Count, user.CanAddBanner, user.CanAddEvent);

        void Authorization()
        {
            if (request.ContextCarrier.AuthenticatedUser!.Id != request.UserId)
                throw new UnauthorizedExeption();
            //TODO - access for admin to get any user status
        }
    }

}
