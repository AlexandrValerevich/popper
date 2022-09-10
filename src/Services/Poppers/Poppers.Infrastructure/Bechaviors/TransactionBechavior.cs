using MediatR;
using Poppers.Application.Common.Cqrs;
using Poppers.Infrastructure.Persistence.EF.Contexts;

namespace Poppers.Infrastructure.Bechaviors;

internal sealed class TransactionBechavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, ICommand<TResponse>
{
    private readonly WriteDbContext _context;

    public TransactionBechavior(WriteDbContext context)
    {
        _context = context;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var response = await next();
            await transaction.CommitAsync();

            return response;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}