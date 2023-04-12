using Gradebook.Application.Configuration.Queries;
using Gradebook.Application.Dtos;

namespace Gradebook.Application.Queries.Students.GetStudents;

public record GetStudentsQuery() : IQuery<IEnumerable<StudentDto>>;