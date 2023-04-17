using FluentValidation;

namespace Gradebook.Application.Commands.Courses.AddCourse;

public class AddCourseCommandValidator : AbstractValidator<AddCourseCommand>
{
    public AddCourseCommandValidator()
    {
        RuleFor(x => x.Name)
         .NotEmpty().WithMessage("Name is required.")
         .MaximumLength(120).WithMessage("Name cannot be longer than 120 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(200).WithMessage("Description cannot be longer than 50 characters.");
    }
}
