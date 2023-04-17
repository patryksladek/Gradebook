using Gradebook.Application.Configuration.Queries;
using Gradebook.Application.Dtos;
using MediatR;

namespace Gradebook.Application.Queries.Courses.GetCourseStudents;

public record GetCourseStudentsQuery(int CourseId) : IQuery<IEnumerable<StudentDto>>;
