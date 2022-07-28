using Poppers.Application.Gif.Common;
using Poppers.Application.Gif.Interfaces;
using GifDomain = Poppers.Domain.Entities.Gif;

namespace Poppers.Infrastructure.Gif.Services
{
    public class GifFileGenerator : IGifFileGenerator
    {
        public Task<GifFile> Generate(GifDomain gif)
        {
            throw new NotImplementedException();
        }
    }
}