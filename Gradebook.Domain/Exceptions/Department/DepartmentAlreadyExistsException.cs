using System.Net;

namespace Gradebook.Domain.Exceptions.Department;

public class DepartmentAlreadyExistsException : GradebookException
{
    public string Name { get; }

    public DepartmentAlreadyExistsException(string name) 
        : base($"Department with name {name} already exists.")
        => Name = name;

    public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;
}