using Gradebook.Application.Configuration.Commands;

namespace Gradebook.Application.Commands.Courses.TransferStudentBetweenCourses;

public record TransferStudentBetweenCoursesCommand(int OldCourseId, int NewCourseId, int StudentId) : ICommand;

