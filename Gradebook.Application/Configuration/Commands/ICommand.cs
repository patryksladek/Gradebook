using MediatR;

namespace Gradebook.Application.Configuration.Commands;

public interface ICommand : IRequest 
{ 

}

public interface ICommand<out TResult> : IRequest<TResult> 
{ 

}