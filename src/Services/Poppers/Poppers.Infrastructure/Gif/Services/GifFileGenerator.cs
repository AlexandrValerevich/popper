using ImageMagick;
using Poppers.Application.Gif.Common;
using Poppers.Application.Gif.Interfaces;
using Shared.GifFile.Clients;
using Shared.GifFile.Contracts.V1.Requests;
using Shared.GifFile.Contracts.V1.Responses;
using GifDomain = Poppers.Domain.Entities.Gif;

namespace Poppers.Infrastructure.Gif.Services
{
    public class GifFileGenerator : IGifFileGenerator
    {
        private readonly IHttpGifFileClient _client;

        public GifFileGenerator(IHttpGifFileClient client)
        {
            _client = client;
        }

        public async Task<GifFile> Generate(GifDomain gif)
        {
            CreateGifResponse createdResponce = await _client.CreateGifFileAsync(new CreateGifFileRequest(
                Images: gif.Frames.Select(f => f.Value),
                Delay: 10
            ), CancellationToken.None);

            GetGifFileByIdResponse gifResponce = await _client.GetGifFileAsync(
                new GetGifFileByIdRequest(createdResponce.Id),
                CancellationToken.None);

            return new GifFile()
            {
                FileStream = gifResponce.StreamGif
            };
        }
    }
}