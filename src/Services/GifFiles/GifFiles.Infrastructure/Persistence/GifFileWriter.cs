using GifFiles.Application.Interfaces;
using ImageMagick;

namespace GifFiles.Infrastructure.Persistence;

public class GifFileWriter : IGifFileWriter
{
    private readonly string _gifFolderBase = Path.Combine(Directory.GetCurrentDirectory(), "Assets");

    public async Task WriteAsync(Guid gifId,
        Guid userId,
        IEnumerable<string> images,
        int delay, CancellationToken token)
    {
        var magicImages = MapMagicImage(images, delay);
        var imageCollection = new MagickImageCollection(magicImages);

        string folderName = Path.Combine(_gifFolderBase, userId.ToString());

        if (!Directory.Exists(folderName))
        {
            Directory.CreateDirectory(folderName);
        }

        string gifName = Path.Combine(folderName, gifId + ".gif");
        await imageCollection.WriteAsync(gifName, token);

        return;
    }

    public ValueTask DeleteByIdAsync(Guid gifId, Guid userId, CancellationToken token)
    {
        var gifFileName = Path.Combine(_gifFolderBase, userId.ToString(), gifId + ".gif");
        File.Delete(gifFileName);
        return ValueTask.CompletedTask;
    }

    public ValueTask DeleteAllUserGifsAsync(Guid userId, CancellationToken token)
    {
        var folderName = Path.Combine(_gifFolderBase, userId.ToString(), ".gif");
        if (Directory.Exists(folderName))
        {
            Directory.Delete(folderName);
        }
        return ValueTask.CompletedTask;
    }

    private static IEnumerable<IMagickImage<ushort>> MapMagicImage(IEnumerable<string> images, int delay)
    {
        return images.Select(i =>
        {
            IMagickImage<ushort> image = MagickImage.FromBase64(i);
            image.AnimationDelay = delay;
            return image;
        });
    }
}