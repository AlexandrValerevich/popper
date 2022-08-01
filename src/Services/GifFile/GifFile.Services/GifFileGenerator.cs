using GifFile.Services.DTO;
using GifFile.Services.Interfaces;
using ImageMagick;

namespace GifFile.Services
{
    public class GifFileGenerator : IGifFileGenerator
    {
        public async Task<GifCreationResultDTO> Generate(IEnumerable<byte[]> images, int delay)
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

            string gifName = Path.Combine(Directory.GetCurrentDirectory(), "Assets", Path.GetRandomFileName() + ".gif");
            await imageCollection.WriteAsync(gifName);


            return new GifCreationResultDTO()
            {
                FileStream = File.Open(gifName, FileMode.Open)
            };
        }
    }
}