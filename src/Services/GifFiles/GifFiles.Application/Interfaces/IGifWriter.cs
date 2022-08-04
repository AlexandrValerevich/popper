using GifFiles.Application.Common;

namespace GifFiles.Application.Interfaces;

public interface IGifWriter
{
    Task<GifCreationResult> WriteAsync(Guid id, IEnumerable<byte[]> images, int delay, CancellationToken token);
}