using FluentValidation;
using MediatR;

namespace Application.Mediator_Pipeline;

public class ValidationBehavior<TRequest, TResult>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResult> where TRequest : notnull
{
    public async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentNullException.ThrowIfNull(next);

        var context = new ValidationContext<TRequest>(request);

        var ValidationResults = await Task.WhenAll(
            validators.Select(
            v => v.ValidateAsync(context, cancellationToken)))
            .ConfigureAwait(false);

        var errors = ValidationResults
            .Where(result => result.IsValid == false)
            .SelectMany(failure => failure.Errors)
            .ToList();

        if (errors.Count != 0)
        {
            throw new ValidationException(errors);
        }

        return await next().ConfigureAwait(false);
    }
}