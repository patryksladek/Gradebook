using FluentValidation;

namespace Gradebook.Application.Commands.Departments.AddDepartment;

public class AddDepartmentCommandValidator : AbstractValidator<AddDepartmentCommand>
{

    public AddDepartmentCommandValidator()
    {
        RuleFor(x => x.Name)
         .NotEmpty().WithMessage("Name is required.")
         .MaximumLength(120).WithMessage("Name cannot be longer than 120 characters.");

        RuleFor(x => x.Building)
            .NotEmpty().WithMessage("Building is required.")
            .MaximumLength(8).WithMessage("Building cannot be longer than 50 characters.");
    }
}
