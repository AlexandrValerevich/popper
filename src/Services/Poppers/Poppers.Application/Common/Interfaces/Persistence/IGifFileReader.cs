using Poppers.Application.Gif.Common;

namespace Poppers.Application.Common.Interfaces.Persistence;

public interface IGifFileReader
{
    Task<GifFile> ReadAsync(Guid gifId, Guid userId, CancellationToken token);
}