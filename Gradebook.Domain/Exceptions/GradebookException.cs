using System.Net;

namespace Gradebook.Domain.Exceptions;

public abstract class GradebookException : Exception
{
    protected GradebookException(string message) : base(message) { }

    public abstract HttpStatusCode StatusCode { get; }
}
