using Poppers.Application.Gif.Interfaces;
using Shared.GifFiles.Contracts.V1.Requests;
using Shared.GifFiles.Clients;
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

        public async Task CreateAsync(GifDomain gif, CancellationToken token)
        {
            await _client.CreateGifFileAsync(new CreateGifFileRequest(
                Id: gif.Id,
                Images: gif.Frames.Select(f => f.Value),
                Delay: 10
            ), token);
        }
    }
}