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

        public async Task CreateAsync(GifDomain gif, Guid userId, CancellationToken token)
        {
            await _client.CreateGifFileAsync(new CreateGifRequest(
                GifId: gif.Id,
                UserId: userId,
                Name: gif.Id.ToString(), // TODO add gif name to domain
                Images: gif.Frames.Select(f => f.Value),
                Delay: 10
            ), token);
        }

        public async Task DeleteAsync(Guid gifId, Guid userId, CancellationToken token)
        {
            await _client.DeleteGifFileByIdAsync(
                new DeleteGifByIdRequest(gifId, userId),
                token);
        }
    }
}