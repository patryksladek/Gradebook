using MediatR;

namespace Gradebook.Application.Commands.Students.UpdateStudent;

public class UpdateStudentCommand : IRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public int YearEnrolled { get; set; }
}

