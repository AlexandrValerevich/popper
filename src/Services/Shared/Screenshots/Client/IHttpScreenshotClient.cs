using Shared.Screenshots.Contracts.V1.Requests;
using Shared.Screenshots.Contracts.V1.Responses;

namespace Shared.Screenshots.Client;

public interface IHttpScreenshotClient
{
    Task<GetScreenshotsResponse> GetScreenshots(GetScreenshotsRequest request,
        CancellationToken token);
}