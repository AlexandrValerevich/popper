using GifFiles.Application.Common;

namespace GifFiles.Application.Interfaces;

public interface IGifFileWriter
{
    Task WriteAsync(Guid gifId, Guid userId, IEnumerable<string> images, int delay, CancellationToken token);
    ValueTask DeleteByIdAsync(Guid gifId, Guid userId, CancellationToken token);
    ValueTask DeleteAllUserGifsAsync(Guid userId, CancellationToken token);
}