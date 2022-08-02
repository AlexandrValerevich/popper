using RestSharp;
using Shared.GifFile.Contracts.V1;
using Shared.GifFile.Contracts.V1.Requests;
using Shared.GifFile.Contracts.V1.Responses;

namespace Shared.GifFile.Clients;

public class HttpGifFileClient : IHttpGifFileClient
{
    private readonly RestClient _client;

    public HttpGifFileClient(HttpClient client)
    {
        _client = new RestClient(client);
    }

    public async Task<GetGifFileByIdResponse> GetGifFileAsync(GetGifFileByIdRequest request,
        CancellationToken token)
    {
        var restRequest = new RestRequest(ApiRoutes.GifFile.GetGifFileById);
        restRequest.AddUrlSegment("Id", request.Id);

        Stream response = await _client.DownloadStreamAsync(restRequest, token);
        return new GetGifFileByIdResponse(response);
    }

    public async Task<CreateGifResponse> CreateGifFileAsync(CreateGifFileRequest request,
       CancellationToken token)
    {
        var restRequest = new RestRequest(ApiRoutes.GifFile.CreateGifFile);
        restRequest.AddBody(request);
        var response = await _client.PostAsync<CreateGifResponse>(restRequest, token);

        return response;
    }

    public async Task DeleteGifFileById(DeleteGifFileByIdRequest request,
       CancellationToken token)
    {

        var restRequest = new RestRequest(ApiRoutes.GifFile.DeleteGifFile);
        restRequest.AddUrlSegment("Id", request.Id);
        await _client.DeleteAsync<CreateGifResponse>(restRequest, token);
    }
}