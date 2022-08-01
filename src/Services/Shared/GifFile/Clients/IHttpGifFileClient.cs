using Shared.GifFile.Contracts.V1.Requests;
using Shared.GifFile.Contracts.V1.Responses;

namespace Shared.GifFile.Clients;

public interface IHttpGifFileClient
{
    Task<GetGifFileResponse> GetGifFileAsync(GetGifFileRequest request, CancellationToken token);
}