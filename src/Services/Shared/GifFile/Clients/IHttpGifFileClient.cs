using Shared.GifFile.Contracts.V1.Requests;
using Shared.GifFile.Contracts.V1.Responses;

namespace Shared.GifFile.Clients;

public interface IHttpGifFileClient
{
    Task<GetGifFileByIdResponse> GetGifFileAsync(GetGifFileByIdRequest request, CancellationToken token);
    Task<CreateGifResponse> CreateGifFileAsync(CreateGifFileRequest request, CancellationToken token);
    Task DeleteGifFileById(DeleteGifFileByIdRequest request, CancellationToken token);
}