using Gradebook.Application.Configuration.Commands;

namespace Gradebook.Application.Commands.Courses.EnrollStudentToCourse;

public record EnrollStudentToCourseCommand(int CourseId, int StudentId) : ICommand;