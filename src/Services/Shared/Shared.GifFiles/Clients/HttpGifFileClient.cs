using RestSharp;
using Shared.GifFiles.Contracts.V1;
using Shared.GifFiles.Contracts.V1.Requests;
using Shared.GifFiles.Contracts.V1.Responses;

namespace Shared.GifFiles.Clients;

internal sealed class HttpGifFileClient : IHttpGifFileClient
{
    private readonly RestClient _client;

    public HttpGifFileClient(HttpClient client)
    {
        _client = new RestClient(client);
    }

    public async Task<GetGifFileByIdResponse> GetGifFileAsync(Guid gifId, GetGifByIdRequest request,
        CancellationToken token)
    {
        var restRequest = new RestRequest(ApiRoutes.GifFile.GetGifFileById);
        restRequest.AddUrlSegment("GifId", gifId);
        restRequest.AddQueryParameter("UserId", request.UserId);

        Stream response = await _client.DownloadStreamAsync(restRequest, token);
        return new GetGifFileByIdResponse(response);
    }

    public async Task<CreateGifFileResponse> CreateGifFileAsync(CreateGifRequest request,
       CancellationToken token)
    {
        var restRequest = new RestRequest(ApiRoutes.GifFile.CreateGifFile);
        restRequest.AddBody(request);
        var response = await _client.PostAsync<CreateGifFileResponse>(restRequest, token);

        return response;
    }

    public async Task DeleteGifFileByIdAsync(Guid gifId, DeleteGifByIdRequest request,
       CancellationToken token)
    {
        var restRequest = new RestRequest(ApiRoutes.GifFile.DeleteGifFile);
        restRequest.AddBody(request);
        restRequest.AddUrlSegment("GifId", gifId);

        await _client.DeleteAsync(restRequest, token);
    }

    public async Task DeleteAllUserGifsAsync(DeleteAllUserGifsRequest request, CancellationToken token)
    {
        var restRequest = new RestRequest(ApiRoutes.GifFile.DeleteAllUserGifs);
        restRequest.AddBody(request);

        await _client.DeleteAsync(restRequest, token);
    }
}