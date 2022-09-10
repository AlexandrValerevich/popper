using GifFiles.Application.Common;

namespace GifFiles.Application.Interfaces;

public interface IGifFileReader
{
    ValueTask<GifFile> ReadByIdAsync(Guid id, Guid userId, CancellationToken token);
}