using Helper.JsuServerResponse;
using Microsoft.AspNetCore.Diagnostics;

namespace API;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        // Fallback
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(JsuContractTemplate.GetContractTemplate("Failed" , message: exception.Message), cancellationToken: cancellationToken);
        return true;
    }
}
