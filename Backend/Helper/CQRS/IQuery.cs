using MediatR;

namespace Helper.CQRS;

public interface IQuery<out TResponse> : IRequest<TResponse> , IBaseRequestProps where TResponse : notnull
{
}