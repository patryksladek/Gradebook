using Gradebook.Application.Configuration.Queries;
using Gradebook.Application.Dtos;

namespace Gradebook.Application.Queries.Students.GetStudentById;

public record GetStudentByIdQuery(int Id) : IQuery<StudentDto>;
