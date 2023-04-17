using Gradebook.Application.Configuration.Queries;
using Gradebook.Application.Dtos;

namespace Gradebook.Application.Queries.Courses.GetCourses;

public record GetCoursesQuery() : IQuery<IEnumerable<CourseDto>>;