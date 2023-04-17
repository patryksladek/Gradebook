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

        RuleFor(x => x.StreetName)
           .NotEmpty().WithMessage("Street name is required.")
           .MaximumLength(100).WithMessage("Street name cannot be longer than 100 characters.");

        RuleFor(x => x.StreetNumber)
            .NotEmpty().WithMessage("Street number is required.")
            .MaximumLength(10).WithMessage("Street number cannot be longer than 10 characters.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required.")
            .MaximumLength(50).WithMessage("City name cannot be longer than 50 characters.");

        RuleFor(x => x.PostalCode)
            .NotEmpty().WithMessage("Postal code is required.")
            .MaximumLength(10).WithMessage("Postal code cannot be longer than 10 characters.");

        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required.")
            .MaximumLength(50).WithMessage("Country name cannot be longer than 50 characters.");
    }
}
