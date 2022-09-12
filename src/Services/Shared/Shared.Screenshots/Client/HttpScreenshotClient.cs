using RestSharp;
using Shared.Screenshots.Contracts.V1;
using Shared.Screenshots.Contracts.V1.Requests;
using Shared.Screenshots.Contracts.V1.Responses;

namespace Shared.Screenshots.Client;

internal sealed class HttpScreenshotClient : IHttpScreenshotClient
{
    private readonly RestClient _client;

    public HttpScreenshotClient(HttpClient client)
    {
        _client = new RestClient(client);
    }

    public async Task<GetScreenshotsResponse> GetScreenshotsAsync(GetScreenshotsRequest queries,
        CancellationToken token)
    {
        var request = new RestRequest(ApiRoutes.Screenshots.GetScreenshots);
        request.AddQueryParameter(nameof(queries.Duration), queries.Duration);
        request.AddQueryParameter(nameof(queries.Selector), queries.Selector);
        request.AddQueryParameter(nameof(queries.Uri), queries.Uri.ToString());

        return await _client.GetAsync<GetScreenshotsResponse>(request, token);
    }
}