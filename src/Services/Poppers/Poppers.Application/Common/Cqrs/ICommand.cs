using MediatR;

namespace Poppers.Application.Common.Cqrs;

public interface ICommand : IRequest
{

}

public interface ICommand<TResponse> : IRequest<TResponse>
{

}