using Gradebook.Application.Dtos;
using MediatR;

namespace Gradebook.Application.Queries.Grades.GetGradeValues;

public record GetGradeValuesQuery : IRequest<IEnumerable<double>>;

