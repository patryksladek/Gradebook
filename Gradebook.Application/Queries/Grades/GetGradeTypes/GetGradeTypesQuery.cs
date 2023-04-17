using Gradebook.Application.Configuration.Queries;
using Gradebook.Application.Dtos;

namespace Gradebook.Application.Queries.Grades.GetGradeTypes;

public record GetGradeTypesQuery : IQuery<IEnumerable<GradeTypeDto>>;
