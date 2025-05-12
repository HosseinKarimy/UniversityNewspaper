using Application.Exceptions;
using Domain.Exceptions;
using FluentValidation;
using Helper.JsuServerResponse;
using Microsoft.AspNetCore.Diagnostics;

namespace API;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        bool isHandled = false;
        if (exception is BusinessRuleViolationException brv)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            await httpContext.Response.WriteAsJsonAsync(JsuContractTemplate.GetContractTemplate(false, message: brv.Message), cancellationToken: cancellationToken);
            isHandled = true;
        } else if (exception is NotFoundException nfe)
        {
            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            await httpContext.Response.WriteAsJsonAsync(JsuContractTemplate.GetContractTemplate(false, message: nfe.Message), cancellationToken: cancellationToken);
            isHandled = true;
        } else if (exception is UnauthorizedExeption ue)
        {
            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await httpContext.Response.WriteAsJsonAsync(JsuContractTemplate.GetContractTemplate(false, message: ue.Message), cancellationToken: cancellationToken);
            isHandled = true;
        } else if (exception is AccessDeniedExcepion)
        {
            httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
            await httpContext.Response.WriteAsJsonAsync(JsuContractTemplate.GetContractTemplate(false, message: exception.Message), cancellationToken: cancellationToken);
            isHandled = true;
        } else if (exception is BadRequestException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            await httpContext.Response.WriteAsJsonAsync(JsuContractTemplate.GetContractTemplate(false, message: exception.Message), cancellationToken: cancellationToken);
            isHandled = true;
        } else if (exception is ValidationException ve)
        {
            httpContext.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
            await httpContext.Response.WriteAsJsonAsync(JsuContractTemplate.GetContractTemplate(false, message: ve.Message), cancellationToken: cancellationToken);
            isHandled = true;
        }
        if (isHandled)
        {
            logger.LogInformation(exception, "Handled exception: {Exception}", exception.Message);
        }

        // Fallback
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(JsuContractTemplate.GetContractTemplate(false, message: exception.Message), cancellationToken: cancellationToken);
        logger.LogError(exception, "Unhandled exception: {Exception}", exception.Message);

        return true;
    }
}
