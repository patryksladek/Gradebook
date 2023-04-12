using Gradebook.Application.Configuration.Queries;
using Gradebook.Application.Dtos;

namespace Gradebook.Application.Queries.Students.GetStudentByEmail;

public record GetStudentByEmailQuery(string Email) : IQuery<StudentDto>;

