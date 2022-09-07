using GifDomain = Poppers.Domain.Entities.Gif;

namespace Poppers.Application.Common.Interfaces.Persistence;

public interface IGifWriter
{
    Task DeleteAsync(Guid gifId, Guid userId, CancellationToken token);
    Task CreateAsync(GifDomain gif, Guid userId, CancellationToken token);
}