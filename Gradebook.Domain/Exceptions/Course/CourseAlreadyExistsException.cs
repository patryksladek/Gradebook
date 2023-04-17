using System.Net;

namespace Gradebook.Domain.Exceptions.Course;

public class CourseAlreadyExistsException : GradebookException
{
    public string Name { get; }

    public CourseAlreadyExistsException(string name)
        : base($"Course with name {name} already exists.")
        => Name = name;

    public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;
}
