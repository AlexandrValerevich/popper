using Poppers.Application.Common.Interfaces.Persistence;
using Poppers.Application.Gif.Common;
using Shared.GifFiles.Clients;
using Shared.GifFiles.Contracts.V1.Requests;

namespace Poppers.Infrastructure.Persistence;

internal sealed class GifFileReader : IGifFileReader
{
    private readonly IHttpGifFileClient _client;

    public GifFileReader(IHttpGifFileClient client)
    {
        _client = client;
    }
    
    public async Task<GifFile> ReadAsync(Guid gifId, Guid userId, CancellationToken token)
    {
        var response = await _client.GetGifFileAsync(
            gifId,
            new GetGifByIdRequest(userId),
            token);

        return new GifFile()
        {
            FileStream = response.StreamGif
        };
    }
}