using MediatR;
using Serilog;

namespace Shared.Common.Behaviors;

public sealed class LogErrorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        try
        {
            return await next();
        }
        catch (Exception e)
        {
            Log.Error("Unexpected exception occur with massage: {Message}", e.Message);
            throw;
        }
    }
}