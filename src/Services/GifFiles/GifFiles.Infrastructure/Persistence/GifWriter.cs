using GifFiles.Application.Common;
using GifFiles.Application.Interfaces;
using ImageMagick;

namespace GifFiles.Infrastructure.Persistence;

public class GifWriter : IGifWriter
{
    public async Task<GifCreationResult> WriteAsync(Guid id,
        IEnumerable<string> images,
        int delay,
        CancellationToken token)
    {
        var magicImages = MapMagicImage(images, delay);

        var imageCollection = new MagickImageCollection(magicImages);
        imageCollection.Optimize();

        string gifName = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Assets",
            id + ".gif");

        await imageCollection.WriteAsync(gifName, token);
        return new GifCreationResult(id);
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