using Microsoft.AspNetCore.Mvc;
using Screenshots.Contracts.V1.Requests;
using Screenshots.Contracts.V1.Responses;
using Screenshots.Services.Interfaces;

namespace Screenshots.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ScreenshotsController : ControllerBase
{
    private readonly IScreenshotService _screenshotService;

    public ScreenshotsController(IScreenshotService screenshotService)
    {
        _screenshotService = screenshotService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetScreenshotsRequest request)
    {
        var screenshots = await _screenshotService.TakeScreenshots(
            request.Uri,
            request.Selector,
            request.Duration);

        return Ok(new GetScreenshotsResponse(screenshots.Screenshots));
    }
}
