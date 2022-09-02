using Shared.GifFiles.Contracts.V1.Requests;
using Shared.GifFiles.Clients;
using GifDomain = Poppers.Domain.Entities.Gif;
using Poppers.Application.Common.Interfaces.Persistence;

namespace Poppers.Infrastructure.Persistence
{
    public class GifWriter : IGifWriter
    {
        private readonly IHttpGifFileClient _client;

        public GifWriter(IHttpGifFileClient client)
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

        public async Task RemoveAsync(Guid id, CancellationToken token)
        {
            await _client.DeleteGifFileByIdAsync(new DeleteGifFileByIdRequest(id),
                token);
        }
    }
}