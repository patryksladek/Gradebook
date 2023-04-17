using Gradebook.Application.Configuration.Commands;

namespace Gradebook.Application.Commands.Students.ChangeStudentDepartment;

public record ChangeStudentDepartmentCommand(int Id, int DepartmentId) : ICommand;

