using Shared.GifFiles.Contracts.V1.Requests;
using Shared.GifFiles.Contracts.V1.Responses;
using Shared.GifFiles.Models;

namespace Shared.GifFiles.Clients;

public interface IHttpGifFileClient
{
    Task<GetGifFileByIdResponse> GetGifFileAsync(Guid gifId, GetGifByIdRequest request, CancellationToken token);
    Task<CreateGifFileResponse> CreateGifFileAsync(CreateGifRequest request, CancellationToken token);
    Task DeleteGifFileByIdAsync(Guid gifId, DeleteGifByIdRequest request, CancellationToken token);
    Task DeleteAllUserGifsAsync(DeleteAllUserGifsRequest request, CancellationToken token);
}