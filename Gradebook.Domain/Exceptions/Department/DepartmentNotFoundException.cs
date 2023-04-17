using System.Net;

namespace Gradebook.Domain.Exceptions.Department;

public class DepartmentNotFoundException : GradebookException
{
    public int Id { get; }

    public DepartmentNotFoundException(int id) 
        : base($"Department with ID {id} was not found.")
        => Id = id;

    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}
