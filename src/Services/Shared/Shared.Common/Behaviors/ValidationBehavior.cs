using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Shared.Common.Behaviors;

internal sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);
        IEnumerable<Task<ValidationResult>> validationTasks =
            _validators.Select(async (x) => await x.ValidateAsync(context));

        ValidationResult[] results = await Task.WhenAll(validationTasks);
        var errorsDictionary = results
            .SelectMany(x => x.Errors);

        if (errorsDictionary.Any())
        {
            throw new ValidationException(errorsDictionary);
        }
        
        return await next();
    }
}