using Poppers.Application.Gif.Common;
using Poppers.Application.Gif.Interfaces;
using Shared.GifFiles.Contracts.V1.Requests;
using Shared.GifFiles.Clients;

namespace Poppers.Infrastructure.Gif.Services;

public class GifReader : IGifReader
{
    private readonly IHttpGifFileClient _client;

    public GifReader(IHttpGifFileClient client)
    {
        _client = client;
    }

    public async Task<GifFile> ReadAsync(Guid id)
    {
        var response = await _client.GetGifFileAsync(
            new GetGifFileByIdRequest(id),
            CancellationToken.None);

        return new GifFile()
        {
            FileStream = response.StreamGif
        };
    }
}