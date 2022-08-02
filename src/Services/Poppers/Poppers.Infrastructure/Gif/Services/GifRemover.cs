using Poppers.Application.Gif.Interfaces;
using Shared.GifFile.Clients;
using Shared.GifFile.Contracts.V1.Requests;

namespace Poppers.Infrastructure.Gif.Services;

public class GifRemover : IGifRemover
{
    private readonly IHttpGifFileClient _client;

    public GifRemover(IHttpGifFileClient client)
    {
        _client = client;
    }

    public async Task RemoveAsync(Guid id)
    {
        await _client.DeleteGifFileById(
            new DeleteGifFileByIdRequest(id),
            CancellationToken.None);
    }
}