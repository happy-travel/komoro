using CSharpFunctionalExtensions;
using FluentValidation;

namespace HappyTravel.Komoro.Api.Infrastructure;

public class GenericValidator<T> : AbstractValidator<T>
{
    public static Result Validate(Action<GenericValidator<T>> configureAction, T entity)
    {
        var validator = new GenericValidator<T>();
        configureAction(validator);
        return validator.GetValidationResult(entity);
    }


    private Result GetValidationResult(T entity)
    {
        var validationResult = base.Validate(entity);
        return validationResult.IsValid
            ? Result.Success()
            : Result.Failure(validationResult.ToString(";"));
    }
}
