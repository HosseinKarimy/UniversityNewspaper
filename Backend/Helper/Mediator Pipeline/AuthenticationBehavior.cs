using Helper.CQRS;
using Helper.Exceptions;
using Helper.Helpers;
using Helper.ServerResponseDto;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Http;

namespace Helper.Mediator_Pipeline;

public class AuthenticationBehavior<TRequest> : IRequestPreProcessor<TRequest> where TRequest : IBaseRequestProps
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthenticationBehavior(IHttpContextAccessor httpContextAccessor)
        => _httpContextAccessor = httpContextAccessor;

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        //Extract Token from request
        var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

        //Send Token To MainJsuServer for Authenticate the user and get user info
        var result = await new HttpRequestSender(token).GetUserInfoFromMainServer() ?? throw new UnauthorizedExeption();

        //Extrace UserId from ServerResponse
        var response = ServerGetUserInfoResponse.FromJsonRequest(result) ?? throw new Exception("Cant Parse Server Response");
        request.ContextCarrier.AuthenticatedUserId = response.User.Id;
    }
}
