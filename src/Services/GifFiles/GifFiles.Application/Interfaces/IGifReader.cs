using GifFiles.Application.Common;

namespace GifFiles.Application.Interfaces;

public interface IGifReader
{
    Task<GifFile> ReadByIdAsync(Guid id);
}