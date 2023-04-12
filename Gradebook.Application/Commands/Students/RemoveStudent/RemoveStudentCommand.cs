using Gradebook.Application.Configuration.Commands;

namespace Gradebook.Application.Commands.Students.RemoveStudent;

public record RemoveStudentCommand(int Id) : ICommand;
