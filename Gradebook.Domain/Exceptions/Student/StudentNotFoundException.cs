using System.Net;

namespace Gradebook.Domain.Exceptions.Student;

public class StudentNotFoundException : GradebookException
{
    public int Id { get; }

    public StudentNotFoundException(int id)
        : base($"Student with ID {id} was not found.")
        => Id = id;

    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}
