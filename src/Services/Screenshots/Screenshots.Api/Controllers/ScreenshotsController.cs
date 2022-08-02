using Microsoft.AspNetCore.Mvc;
using Screenshots.Application.Interfaces;
using Shared.Screenshots.Contracts.V1;
using Shared.Screenshots.Contracts.V1.Requests;
using Shared.Screenshots.Contracts.V1.Responses;

namespace Screenshots.Api.Controllers;

[ApiController]
public class ScreenshotsController : ControllerBase
{
    private readonly IScreenshotService _screenshotService;

    public ScreenshotsController(IScreenshotService screenshotService)
    {
        _screenshotService = screenshotService;
    }

    [HttpGet(ApiRoutes.Screenshots.GetScreenshots)]
    public async Task<IActionResult> Get([FromQuery] GetScreenshotsRequest request)
    {
        var screenshots = await _screenshotService.TakeScreenshots(
            request.Uri,
            request.Selector,
            request.Duration);

        return Ok(new GetScreenshotsResponse(screenshots.Screenshots));
    }
}
