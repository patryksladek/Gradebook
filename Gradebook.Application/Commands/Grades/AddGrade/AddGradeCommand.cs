using Gradebook.Application.Configuration.Commands;

namespace Gradebook.Application.Commands.Grades.AddGrade;

public class AddGradeCommand : ICommand
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public int Type { get; set; }
    public double Grade { get; set; }
}
