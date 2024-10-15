using Helper.CQRS;
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
        var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        //TODO - Impeliment Get User Id
        var result = await new HttpRequestSender(token).GetUserInfoFromMainServer();
        var response = ServerGetUserInfoResponse.FromJsonRequest(result);
        request.UserId = response.User.Id;
    }
}
