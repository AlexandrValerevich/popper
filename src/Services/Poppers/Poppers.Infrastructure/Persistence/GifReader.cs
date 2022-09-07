using Poppers.Application.Gif.Common;
using Shared.GifFiles.Contracts.V1.Requests;
using Shared.GifFiles.Clients;
using Poppers.Application.Common.Interfaces.Persistence;

namespace Poppers.Infrastructure.Persistence;

public class GifReader : IGifReader
{
    private readonly IHttpGifFileClient _client;

    public GifReader(IHttpGifFileClient client)
    {
        _client = client;
    }

    public async Task<GifFile> ReadAsync(Guid gifId, Guid userId, CancellationToken token)
    {
        var response = await _client.GetGifFileAsync(
            new GetGifByIdRequest(gifId, userId),
            token);

        return new GifFile()
        {
            FileStream = response.StreamGif
        };
    }
}