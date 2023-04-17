using System.Net;

namespace Gradebook.Domain.Exceptions.Department;

public class DepartmentHasAssignedStudentsException : GradebookException
{
    public string Name { get; }

    public DepartmentHasAssignedStudentsException(string name)
        : base($"Department with name {name} has assigned students.")
        => Name = name;

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}