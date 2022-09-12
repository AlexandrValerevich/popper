using GifFiles.Application.Common;
using GifFiles.Application.Interfaces;

namespace GifFiles.Infrastructure.Persistence;

internal sealed class GifFileReader : IGifFileReader
{
    private readonly string _gifFolderBase = Path.Combine(Directory.GetCurrentDirectory(), "Assets");

    public ValueTask<GifFile> ReadByIdAsync(Guid gifId, Guid userId, CancellationToken token)
    {
        string gifFileName = Path.Combine(_gifFolderBase, userId.ToString(), gifId + ".gif");
        if (!File.Exists(gifFileName))
        {
            return ValueTask.FromResult<GifFile>(null);
        }

        var gifFile = new GifFile()
        {
            Stream = File.OpenRead(gifFileName)
        };

        return ValueTask.FromResult(gifFile);
    }
}