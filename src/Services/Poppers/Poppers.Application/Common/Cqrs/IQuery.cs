using MediatR;

namespace Poppers.Application.Common.Cqrs;

public interface IQuery : IRequest
{

}

public interface IQuery<TResponse> : IRequest<TResponse>
{

}