using Gradebook.Application.Dtos;
using MediatR;

namespace Gradebook.Application.Queries.Students.GetStudents;

public record GetStudentsQuery() : IRequest<IEnumerable<StudentDto>>;