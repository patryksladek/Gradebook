using FluentValidation;
using Gradebook.Domain.Entities;

namespace Gradebook.Application.Commands.Grades.AddGrade;

public class AddGradeCommandValidator : AbstractValidator<AddGradeCommand>
{
    public AddGradeCommandValidator()
    {
        RuleFor(x => x.StudentId)
            .NotNull().WithMessage("Student ID is required.");

        RuleFor(x => x.CourseId)
            .NotNull().WithMessage("Course ID is required.");

        RuleFor(x => x.Type).IsInEnum().WithName(nameof(AddGradeCommand.Type))
            .WithMessage($"'{nameof(AddGradeCommand.Type)}' must be a valid GradeType enum value.");

        RuleFor(x => x.Grade).Custom((value, context) =>
        {
            if (!GradeValue.IsValid(value))
            {
                context.AddFailure($"'{nameof(AddGradeCommand.Grade)}' must be a valid GradeValue enum value.");
            }
        });
    }
}