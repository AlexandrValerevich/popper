using GifFiles.Application.Common;
using GifFiles.Application.Interfaces;

namespace GifFiles.Infrastructure.Persistence;

public class GifReader : IGifReader
{
    public Task<GifFile> ReadByIdAsync(Guid id)
    {
        var gifFileName = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Assets",
            id + ".gif");

        return Task.FromResult(new GifFile()
        {
            Id = id,
            Stream = File.Open(gifFileName, FileMode.Open)
        });
    }
}