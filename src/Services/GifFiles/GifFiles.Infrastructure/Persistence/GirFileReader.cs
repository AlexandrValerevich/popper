using GifFiles.Application.Common;
using GifFiles.Application.Interfaces;

namespace GifFiles.Infrastructure.Persistence;

public class GifFileReader : IGifFileReader
{
    public ValueTask<GifFile> ReadByIdAsync(Guid id, CancellationToken token)
    {
        string gifFileName = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Assets",
            id + ".gif");

        return ValueTask.FromResult(new GifFile()
        {
            Id = id,
            Stream = File.Open(gifFileName, FileMode.Open)
        });
    }
}