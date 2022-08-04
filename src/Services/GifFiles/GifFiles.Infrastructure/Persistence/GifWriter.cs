using GifFiles.Application.Common;
using GifFiles.Application.Interfaces;
using ImageMagick;

namespace GifFiles.Infrastructure.Persistence;

public class GifWriter : IGifWriter
{
    public async Task<GifCreationResult> WriteAsync(Guid id,
        IEnumerable<byte[]> images,
        int delay,
        CancellationToken token)
    {
        IEnumerable<MagickImage> magicImages = MapMagicImage(images, delay);

        var imageCollection = new MagickImageCollection(magicImages);
        imageCollection.Optimize();

        string gifName = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Assets",
            id + ".gif");

        await imageCollection.WriteAsync(gifName, token);
        return new GifCreationResult(id);
    }

    private static IEnumerable<MagickImage> MapMagicImage(IEnumerable<byte[]> images, int delay)
    {
        return images.Select(i =>
        {
            var image = new MagickImage(new Span<byte>(i))
            {
                AnimationDelay = delay
            };
            return image;
        });
    }
}