using MediatR;

namespace Gradebook.Application.Commands.Students.RemoveStudent;

public record RemoveStudentCommand(int Id) : IRequest;
