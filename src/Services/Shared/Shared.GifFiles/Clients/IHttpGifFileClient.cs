using Shared.GifFiles.Contracts.V1.Requests;
using Shared.GifFiles.Contracts.V1.Responses;

namespace Shared.GifFiles.Clients;

public interface IHttpGifFileClient
{
    Task<GetGifFileByIdResponse> GetGifFileAsync(GetGifFileByIdRequest request, CancellationToken token);
    Task<CreateGifResponse> CreateGifFileAsync(CreateGifFileRequest request, CancellationToken token);
    Task DeleteGifFileById(DeleteGifFileByIdRequest request, CancellationToken token);
}