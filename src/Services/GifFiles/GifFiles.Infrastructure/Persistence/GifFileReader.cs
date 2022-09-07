using GifFiles.Application.Common;
using GifFiles.Application.Interfaces;

namespace GifFiles.Infrastructure.Persistence;

public class GifFileReader : IGifFileReader
{
    private readonly string _gifFolderBase = Path.Combine(Directory.GetCurrentDirectory(), "Assets");

    public ValueTask<GifFile> ReadByIdAsync(Guid gifId, Guid userId, CancellationToken token)
    {
        string folderName = Path.Combine(_gifFolderBase, userId.ToString());
        if (!Directory.Exists(folderName))
        {
            return ValueTask.FromResult<GifFile>(null);
        }

        string gifFileName = Path.Combine(folderName, gifId + ".gif");
        var gifFile = new GifFile()
        {
            Id = gifId,
            Stream = File.OpenRead(gifFileName)
        };
        
        return ValueTask.FromResult(gifFile);
    }
}