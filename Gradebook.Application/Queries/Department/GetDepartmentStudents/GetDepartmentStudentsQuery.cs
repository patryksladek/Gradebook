using Gradebook.Application.Configuration.Queries;
using Gradebook.Application.Dtos;
using MediatR;

namespace Gradebook.Application.Queries.Department.GetDepartmentStudents;

public record class GetDepartmentStudentsQuery(int Id) : IQuery<IEnumerable<StudentDto>>;
