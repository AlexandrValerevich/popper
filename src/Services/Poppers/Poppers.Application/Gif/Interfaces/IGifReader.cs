using Poppers.Application.Gif.Common;

namespace Poppers.Application.Gif.Interfaces;

public interface IGifReader
{
    Task<GifFile> ReadAsync(Guid id, CancellationToken token);
}