using ImageMagick;
using Poppers.Application.Gif.Common;
using Poppers.Application.Gif.Interfaces;
using GifDomain = Poppers.Domain.Entities.Gif;

namespace Poppers.Infrastructure.Gif.Services
{
    public class GifFileGenerator : IGifFileGenerator
    {
        public async Task<GifFile> Generate(GifDomain gif)
        {
            var images = gif.Frames.Select(f =>
            {
                var image = new MagickImage(f.Value)
                {
                    AnimationDelay = gif.Delay
                };
                return image;
            });

            var imageCollection = new MagickImageCollection(images);

            string gifName = Path.Combine(Directory.GetCurrentDirectory(), Path.GetRandomFileName() + ".gif");
            await imageCollection.Mosaic().WriteAsync(gifName);

            return new GifFile()
            {
                FileStream = File.Open(gifName, FileMode.Open)
            };
        }
    }
}