using Gradebook.Application.Configuration.Commands;

namespace Gradebook.Application.Commands.Departments.RemoveDepartment;

public record RemoveDepartmentCommand(int Id) : ICommand;
