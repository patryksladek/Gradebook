using Gradebook.Application.Configuration.Commands;
using Gradebook.Application.Dtos;

namespace Gradebook.Application.Commands.Students.AddStudent;

public class AddStudentCommand : ICommand<StudentDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public int YearEnrolled { get; set; }
}
