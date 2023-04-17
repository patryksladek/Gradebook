namespace Gradebook.Domain.Entities;

public class Student : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public int YearEnrolled { get; set; }

    public Address Address { get; set; }

    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    public ICollection<StudentCourse> StudentCourses { get; set; }
}
