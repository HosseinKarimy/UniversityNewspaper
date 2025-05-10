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
        }

        // Fallback
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(JsuContractTemplate.GetContractTemplate("Failed" , message: exception.Message), cancellationToken: cancellationToken);
        return true;
    }
}
