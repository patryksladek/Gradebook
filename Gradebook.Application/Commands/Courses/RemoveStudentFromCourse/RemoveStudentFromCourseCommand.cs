using Gradebook.Application.Configuration.Commands;

namespace Gradebook.Application.Commands.Courses.RemoveStudentFromCourse;

public record RemoveStudentFromCourseCommand(int CourseId, int StudentId) : ICommand;

