using System.Net;

namespace Gradebook.Domain.Exceptions.Student;

public class StudentIsNotEnrolledToCourseException : GradebookException
{
    public string FirstName { get; }
    public string LastName { get; }
    public string CourseName { get; }

    public StudentIsNotEnrolledToCourseException(string firstName, string lastName, string courseName) 
        : base($"Student {firstName} {lastName} is not enrolled to course {courseName}.")
    {
        FirstName = firstName;
        LastName = lastName;
        CourseName = courseName;
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}
