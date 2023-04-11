using System.Net;

namespace Gradebook.Domain.Exceptions.Student;

public class StudentAlreadyExistsException : GradebookException
{
    public string Email { get; }

    public StudentAlreadyExistsException(string email)
        : base($"Student with email {email} already exists.")
        => Email = email;

    public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;
}
