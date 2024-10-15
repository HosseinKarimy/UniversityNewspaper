using MediatR;

namespace Helper.CQRS;

public interface ICommand : IRequest<Unit>, IBaseRequestProps
{  
}

public interface ICommand<out TResponse> : IRequest<TResponse>, IBaseRequestProps
{
}
