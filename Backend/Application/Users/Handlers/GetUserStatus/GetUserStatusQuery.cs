using Application.Users.DTO;
using Domain.StronglyTypes;
using Helper.CQRS;
using Helper.HelperModels;

namespace Application.Users.Handlers.GetUserStatus;

public record GetUserStatusQuery(UserId UserId) : IQuery<UserStatusDto>
{
    public ImportantHttpContextCarrier ContextCarrier { get; set; } = new();
}

