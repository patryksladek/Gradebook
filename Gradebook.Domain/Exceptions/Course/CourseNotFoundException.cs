using System.Net;

namespace Gradebook.Domain.Exceptions.Course;

public class CourseNotFoundException : GradebookException
{
    public int Id { get; }

    public CourseNotFoundException(int id) 
        : base($"Course with ID {id} was not found.")
        => Id = id;

    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}
