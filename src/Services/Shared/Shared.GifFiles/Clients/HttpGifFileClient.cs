using RestSharp;
using Shared.GifFiles.Contracts.V1;
using Shared.GifFiles.Contracts.V1.Requests;
using Shared.GifFiles.Contracts.V1.Responses;

namespace Shared.GifFiles.Clients;

public class HttpGifFileClient : IHttpGifFileClient
{
    private readonly RestClient _client;

    public HttpGifFileClient(HttpClient client)
    {
        _client = new RestClient(client);
    }

    public async Task<GetGifFileByIdResponse> GetGifFileAsync(GetGifByIdRequest request,
        CancellationToken token)
    {
        var restRequest = new RestRequest(ApiRoutes.GifFile.GetGifFileById);
        restRequest.AddUrlSegment("UserId", request.UserId);
        restRequest.AddUrlSegment("GifId", request.GifId);

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

    public async Task DeleteGifFileByIdAsync(DeleteGifByIdRequest request,
       CancellationToken token)
    {
        var restRequest = new RestRequest(ApiRoutes.GifFile.DeleteGifFile);
        restRequest.AddUrlSegment("UserId", request.GifId);
        restRequest.AddUrlSegment("GifId", request.GifId);
        
        await _client.DeleteAsync(restRequest, token);
    }
}