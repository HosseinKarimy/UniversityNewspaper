using Helper.CQRS;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Mediator_Pipeline;

public class LoggingBehavior<TRequest, TResponse>(ILogger<TRequest> logger) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation(request.ToString());
        var result = await next();
        logger.LogInformation(result?.ToString());
        return result;
    }
}
