using Application.Users.Repositroies;
using Domain.StronglyTypes;
using Helper.CQRS;
using MediatR;

namespace Application.Users.Handlers.SetUserAccess;

public class SetUserAccessHandler(IUserRepository userRepository) : ICommandHandler<SetUserAccessCommand>
{
    public async Task<Unit> Handle(SetUserAccessCommand request, CancellationToken cancellationToken)
    {
        Authorization();
        var TargetUser = await userRepository.GetByIdAsync(UserId.Of(request.UserAccess.UserId),cancellationToken) ?? throw new Exception("User Not Found");
        if (request.UserAccess.CanAddBanner is not null)
        {
            TargetUser.CanAddBanner = request.UserAccess.CanAddBanner.Value;
        }
        if (request.UserAccess.CanAddEvent is not null)
        {
            TargetUser.CanAddEvent = request.UserAccess.CanAddEvent.Value;
        }
        userRepository.Update(TargetUser);
        await userRepository.SaveChangesAsync(cancellationToken);

        return new Unit();

        void Authorization()
        {
            if (request.ContextCarrier.AuthenticatedUser!.Id.Value != 8800)
                throw new Exception("Unauthorized");
        }
    }
}
