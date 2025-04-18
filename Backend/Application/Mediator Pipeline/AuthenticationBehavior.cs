using Application.Bazaar.BazzarRepositories;
using Domain.Models;
using Domain.StronglyTypes;
using Helper.CQRS;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Http;

namespace Application.Mediator_Pipeline;

public class AuthenticationBehavior<TRequest>(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository) : IRequestPreProcessor<TRequest> where TRequest : IBaseRequestProps
{
    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        //Extract Token from request
        var token = httpContextAccessor.HttpContext.Request.Headers["Authorization"];

        ////Send Token To MainJsuServer for Authenticate the user and get user info
        //var result = await new HttpRequestSender(token).GetUserInfoFromMainServer() ?? throw new UnauthorizedExeption();

        ////Extrace Id from ServerResponse
        //var response = ServerGetUserInfoResponse.FromJsonRequest(result) ?? throw new Exception("Cant Parse Server Response");
        //var user = await userRepository.AddUserIfNotExistAsync(CreateNewUser(response.User.Id), cancellationToken);
        //request.ContextCarrier.AuthenticatedUser = user;
        //request.ContextCarrier.AuthenticatedUser = new() { Id = UserId.Of(8800) };
        
        await FakeJsuAuthAsync();

        async Task FakeJsuAuthAsync()
        {
            var user = await userRepository.AddUserIfNotExistAsync(CreateNewUser(int.Parse(token)), cancellationToken);
            request.ContextCarrier.AuthenticatedUser = new() { Id = user.Id };
        }
    }

    

    private static User CreateNewUser(int userId) => new() { Id = UserId.Of(userId) };
}
