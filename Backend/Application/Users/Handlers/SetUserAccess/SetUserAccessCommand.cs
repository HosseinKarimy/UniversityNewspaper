using Application.Users.DTO;
using Helper.CQRS;
using Helper.HelperModels;
using MediatR;

namespace Application.Users.Handlers.SetUserAccess;

public record SetUserAccessCommand(UserAccessDto UserAccess) : ICommand<Unit>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

