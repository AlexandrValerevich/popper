namespace Poppers.Application.Common.Interfaces.Persistence;

public interface IGifRemover
{
    Task RemoveAsync(Guid Id, CancellationToken token);
}