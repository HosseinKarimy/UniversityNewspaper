using Application.Exceptions;
using Domain.Exceptions;
using Helper.JsuServerResponse;
using Microsoft.AspNetCore.Diagnostics;

namespace API;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {

        if (exception is BusinessRuleViolationException brv)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            await httpContext.Response.WriteAsJsonAsync(JsuContractTemplate.GetContractTemplate("Failed", message: brv.Message), cancellationToken: cancellationToken);
            return true;
        } else if (exception is NotFoundException nfe)
        {
            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            await httpContext.Response.WriteAsJsonAsync(JsuContractTemplate.GetContractTemplate("Failed", message: nfe.Message), cancellationToken: cancellationToken);
            return true;
        } else if (exception is UnauthorizedExeption ue)
        {
            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await httpContext.Response.WriteAsJsonAsync(JsuContractTemplate.GetContractTemplate("Failed", message: ue.Message), cancellationToken: cancellationToken);
            return true;
        } else if (exception is AccessDeniedExcepion)
        {
            httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
            await httpContext.Response.WriteAsJsonAsync(JsuContractTemplate.GetContractTemplate("Failed", message: exception.Message), cancellationToken: cancellationToken);
            return true;
        } else if (exception is BadRequestException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            await httpContext.Response.WriteAsJsonAsync(JsuContractTemplate.GetContractTemplate("Failed", message: exception.Message), cancellationToken: cancellationToken);
            return true;
        }

        // Fallback
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(JsuContractTemplate.GetContractTemplate("Failed", message: exception.Message), cancellationToken: cancellationToken);
        return true;
    }
}
