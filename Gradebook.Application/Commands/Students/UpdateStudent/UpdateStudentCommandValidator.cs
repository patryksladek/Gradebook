using FluentValidation;

namespace Gradebook.Application.Commands.Students.UpdateStudent;

public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name cannot be longer than 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name cannot be longer than 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email address is required.")
            .MaximumLength(100).WithMessage("Email address cannot be longer than 100 characters.")
            .EmailAddress().WithMessage("Invalid email address format.");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("Date of birth is required.")
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now.AddYears(-18))).WithMessage("Student must be at least 18 years old.");

        RuleFor(x => x.YearEnrolled)
            .NotEmpty().WithMessage("Year enrolled is required.")
            .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("Invalid year enrolled.");
    }
}
