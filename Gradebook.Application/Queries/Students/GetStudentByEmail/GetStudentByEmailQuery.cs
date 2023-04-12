using Gradebook.Application.Dtos;
using MediatR;

namespace Gradebook.Application.Queries.Students.GetStudentByEmail;

public record GetStudentByEmailQuery(string Email) : IRequest<StudentDto>;

