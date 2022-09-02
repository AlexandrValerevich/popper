using GifDomain = Poppers.Domain.Entities.Gif;

namespace Poppers.Application.Common.Interfaces.Persistence;

public interface IGifWriter
{
    Task RemoveAsync(Guid Id, CancellationToken token);
    Task CreateAsync(GifDomain gif, CancellationToken token);
}