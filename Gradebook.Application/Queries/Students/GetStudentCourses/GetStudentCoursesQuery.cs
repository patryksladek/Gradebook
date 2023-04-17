using Gradebook.Application.Configuration.Queries;
using Gradebook.Application.Dtos;

namespace Gradebook.Application.Queries.Students.GetStudentCourses;

public record class GetStudentCoursesQuery(int StudentId) : IQuery<IEnumerable<CourseDto>>;

