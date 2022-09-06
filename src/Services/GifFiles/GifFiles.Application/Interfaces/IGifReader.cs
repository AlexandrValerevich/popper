using GifFiles.Application.Common;

namespace GifFiles.Application.Interfaces;

public interface IGifReader
{
    Task<IEnumerable<Gif>> ReadAllAsync(Guid userId, CancellationToken token);
}