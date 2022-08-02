using Poppers.Application.Gif.Common;
using Poppers.Application.Gif.Interfaces;
using Shared.GifFile.Clients;
using Shared.GifFile.Contracts.V1.Requests;

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