using Poppers.Application.Common.Interfaces.Persistence;
using Poppers.Application.Gif.Common;
using Shared.GifFiles.Clients;
using Shared.GifFiles.Contracts.V1.Requests;
using GifDomain = Poppers.Domain.Entities.Gif;

namespace Poppers.Infrastructure.Persistence;

public class GifFileWriter : IGifFileWriter
{
    private readonly IHttpGifFileClient _client;

    public GifFileWriter(IHttpGifFileClient client)
    {
        _client = client;
    }

    public async Task CreateAsync(GifDomain gif,
        Guid userId,
        ScreenshotList screenshots,
        CancellationToken token)
    {
        await _client.CreateGifFileAsync(
            new CreateGifRequest(
                GifId: gif.Id,
                UserId: userId,
                Name: gif.Name,
                Images: screenshots.Value,
                Delay: 10
            ),
            token);
    }

    public async Task DeleteAllUserGifsAsync(Guid userId, CancellationToken token)
    {
        await _client.DeleteAllUserGifsAsync(
            new DeleteAllUserGifsRequest(userId), token);
    }

    public async Task DeleteAsync(Guid gifId, Guid userId, CancellationToken token)
    {
        await _client.DeleteGifFileByIdAsync(
            gifId,
            new DeleteGifByIdRequest(userId),
            token);
    }
}