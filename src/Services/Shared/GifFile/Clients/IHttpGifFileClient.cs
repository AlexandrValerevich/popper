using Shared.GifFile.Contracts.V1.Requests;
using Shared.GifFile.Contracts.V1.Responses;

namespace Shared.GifFile.Clients;

public interface IHttpGifFileClient
{
    Task<GetGifFileByIdResponse> GetGifFileAsync(GetGifFileByIdRequest request, CancellationToken token);
    Task<CreateGifResponse> CreateGifFileAsync(CreateGifFileRequest requestBody, CancellationToken token);
}