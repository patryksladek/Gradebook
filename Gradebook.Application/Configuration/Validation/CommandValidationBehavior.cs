using FluentValidation;
using FluentValidation.Results;
using Gradebook.Application.Configuration.Commands;
using MediatR;

namespace Gradebook.Application.Configuration.Validation;

public class CommandValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class, ICommand<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public CommandValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }
        var context = new ValidationContext<TRequest>(request);
        var errorsList = _validators
            .Select(x =>  x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .GroupBy(
                x => x.PropertyName,
                x => x.ErrorMessage,
                (propertyName, errorMessages) => new ValidationFailure()
                {
                    PropertyName = propertyName,
                    ErrorMessage = string.Join(",", errorMessages.Distinct())
                })
            .ToList();

        if (errorsList.Any())
        {
            throw new ValidationException("Invalid command, reasons:", errorsList);
        }

        return await next();
    }
}
