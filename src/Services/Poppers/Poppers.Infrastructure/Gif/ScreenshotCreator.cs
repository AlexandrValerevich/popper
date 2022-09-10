using Poppers.Application.Common.Interfaces.Gif;
using Poppers.Application.Gif.Common;
using Shared.Screenshots.Client;
using Shared.Screenshots.Contracts.V1.Requests;
using GifDomain = Poppers.Domain.Entities.Gif;

namespace Poppers.Infrastructure.Gif;

public class ScreenshotCreator : IScreenshotCreator
{
    private readonly IHttpScreenshotClient _client;

    public ScreenshotCreator(IHttpScreenshotClient client)
    {
        _client = client;
    }

    public async Task<ScreenshotList> TakeScreenshotsAsync(GifDomain gif, CancellationToken token)
    {
        var response = await _client.GetScreenshotsAsync(
            new GetScreenshotsRequest(gif.Uri, gif.Selector, gif.Duration),
            token);

        return new ScreenshotList()
        {
            Value = response.Screenshots
        };
    }
}