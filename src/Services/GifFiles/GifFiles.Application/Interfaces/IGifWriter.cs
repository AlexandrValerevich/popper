using GifFiles.Application.Common;

namespace GifFiles.Application.Interfaces;

public interface IGifWriter
{
    Task<GifCreationResult> Write(IEnumerable<byte[]> images, int delay);
}