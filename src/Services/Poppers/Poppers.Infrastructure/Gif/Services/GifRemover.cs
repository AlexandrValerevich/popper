using Poppers.Application.Gif.Interfaces;
using Shared.GifFiles.Contracts.V1.Requests;
using Shared.GifFiles.Clients;

namespace Poppers.Infrastructure.Gif.Services;

public class GifRemover : IGifRemover
{
    private readonly IHttpGifFileClient _client;

    public GifRemover(IHttpGifFileClient client)
    {
        _client = client;
    }

    public async Task RemoveAsync(Guid id, CancellationToken token)
    {
        await _client.DeleteGifFileByIdAsync(
            new DeleteGifFileByIdRequest(id),
            token);
    }
}