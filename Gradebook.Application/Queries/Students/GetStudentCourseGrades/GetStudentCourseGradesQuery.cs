using Gradebook.Application.Configuration.Queries;
using Gradebook.Application.Dtos;

namespace Gradebook.Application.Queries.Students.GetStudentCourseGrades;

public record class GetStudentCourseGradesQuery(int StudentId, int CourseId) : IQuery<IEnumerable<GradeDto>>;
