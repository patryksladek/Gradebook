using System.Net;

namespace Gradebook.Domain.Exceptions.Student;

public class StudentIsAlreadyEnrolledToCourseException : GradebookException
{
    public string FirstName { get; }
    public string LastName { get; }
    public string CourseName { get; }

    public StudentIsAlreadyEnrolledToCourseException(string firstName, string lastName, string courseName)
        : base($"Student {firstName} {lastName} is already enrolled to course {courseName}.")
    {
        FirstName = firstName;
        LastName = lastName;
        CourseName = courseName;
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}
