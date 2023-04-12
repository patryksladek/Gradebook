using MediatR;

namespace Gradebook.Application.Configuration.Queries;

public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{

}
