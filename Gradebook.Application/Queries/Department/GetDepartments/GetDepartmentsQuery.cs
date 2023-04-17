using Gradebook.Application.Configuration.Queries;
using Gradebook.Application.Dtos;

namespace Gradebook.Application.Queries.Departments.GetDepartments;

public record GetDepartmentsQuery() : IQuery<IEnumerable<DepartmentDto>>;
