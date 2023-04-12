using Gradebook.Application.Dtos;
using MediatR;

namespace Gradebook.Application.Queries.Students.GetStudentById;

public record GetStudentByIdQuery(int Id) : IRequest<StudentDto>;
