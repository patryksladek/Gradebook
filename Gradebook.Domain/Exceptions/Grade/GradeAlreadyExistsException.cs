using Gradebook.Domain.Entities;
using System.Net;

namespace Gradebook.Domain.Exceptions.Grade;

public class GradeAlreadyExistsException : GradebookException
{
    public GradeType Type { get; }

    public GradeAlreadyExistsException(GradeType type)
        : base($"Grade with type {type.GetDisplayName()} already exists.")
        => Type = type;

    public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;
}
