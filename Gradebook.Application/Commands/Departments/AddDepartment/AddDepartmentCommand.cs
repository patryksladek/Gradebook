using Gradebook.Application.Configuration.Commands;
using Gradebook.Application.Dtos;

namespace Gradebook.Application.Commands.Departments.AddDepartment;

public class AddDepartmentCommand : ICommand<DepartmentDto>
{
    public string Name { get; set; }
    public string Building { get; set; }
}
