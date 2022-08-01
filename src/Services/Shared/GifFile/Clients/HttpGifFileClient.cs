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

    public async Task<GetGifFileByIdResponse> GetGifFileAsync(GetGifFileByIdRequest queries,
        CancellationToken token)
    {
        var request = new RestRequest(ApiRoutes.GifFile.GetGifFileById);
        request.AddUrlSegment("id", queries.Id);

        Stream response = await _client.DownloadStreamAsync(request, token);
        return new GetGifFileByIdResponse(response);
    }

    public async Task<CreateGifResponse> CreateGifFileAsync(CreateGifFileRequest requestBody,
       CancellationToken token)
    {
        var request = new RestRequest(ApiRoutes.GifFile.CreateGifFile);
        request.AddBody(requestBody);
        var response = await _client.PostAsync<CreateGifResponse>(request, token);
        
        return response;
    }
}