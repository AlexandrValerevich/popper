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

    public async Task<GetGifFileResponse> GetGifFileAsync(GetGifFileRequest queries,
        CancellationToken token)
    {
        var request = new RestRequest(ApiRoutes.GifFile.GetGifFile);
        // request.AddQueryParameter(nameof(queries.Images), queries.Images.ToArray());
        request.AddQueryParameter(nameof(queries.Delay), queries.Delay);

        Stream response = await _client.DownloadStreamAsync(request, token);
        return new GetGifFileResponse(response);
    }
}