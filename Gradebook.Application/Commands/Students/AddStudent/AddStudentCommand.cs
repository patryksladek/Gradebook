using Gradebook.Application.Configuration.Commands;
using Gradebook.Application.Dtos;

namespace Gradebook.Application.Commands.Students.AddStudent;

public class AddStudentCommand : ICommand<StudentDetailsDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public int YearEnrolled { get; set; }

    public string StreetName { get; set; }
    public string StreetNumber { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }

    public int DepartmentId { get; set; }
}
