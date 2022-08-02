using GifFiles.Application.Common;
using GifFiles.Application.Interfaces;
using ImageMagick;

namespace GifFiles.Infrastructure.Persistence;

public class GifWriter : IGifWriter
{
    public async Task<GifCreationResult> Write(Guid id, IEnumerable<byte[]> images, int delay)
    {
        var magicImages = images.Select(i =>
          {
              var image = new MagickImage(new Span<byte>(i))
              {
                  AnimationDelay = delay
              };
              return image;
          });

        var imageCollection = new MagickImageCollection(magicImages);
        imageCollection.Optimize();

        string gifName = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Assets",
            id + ".gif");

        await imageCollection.WriteAsync(gifName);

        return new GifCreationResult(id);
    }
}