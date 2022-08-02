using Poppers.Application.Gif.Interfaces;
using Shared.GifFile.Clients;
using Shared.GifFile.Contracts.V1.Requests;
using GifDomain = Poppers.Domain.Entities.Gif;

namespace Poppers.Infrastructure.Gif.Services
{
    public class GifCreator : IGifCreator
    {
        private readonly IHttpGifFileClient _client;

        public GifCreator(IHttpGifFileClient client)
        {
            _client = client;
        }

        public async Task Create(GifDomain gif)
        {
            await _client.CreateGifFileAsync(new CreateGifFileRequest(
                Id: gif.Id,
                Images: gif.Frames.Select(f => f.Value),
                Delay: 10
            ), CancellationToken.None);
        }
    }
}