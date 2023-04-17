using Gradebook.Application.Dtos;
using MediatR;

namespace Gradebook.Application.Queries.Students.GetStudentsWithDetails;

public record GetStudentsWithDetailsQuery() : IRequest<IEnumerable<StudentDetailsDto>>;