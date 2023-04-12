using MediatR;

namespace Gradebook.Application.Configuration.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
{

}
