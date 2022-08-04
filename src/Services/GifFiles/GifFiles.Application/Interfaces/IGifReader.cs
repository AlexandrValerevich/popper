using GifFiles.Application.Common;

namespace GifFiles.Application.Interfaces;

public interface IGifReader
{
    ValueTask<GifFile> ReadByIdAsync(Guid id, CancellationToken token);
}