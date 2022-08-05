using MediatR;
using Microsoft.AspNetCore.Mvc;
using Screenshots.Application.Interfaces;
using Screenshots.Application.Queries;
using Shared.Screenshots.Contracts.V1;
using Shared.Screenshots.Contracts.V1.Requests;
using Shared.Screenshots.Contracts.V1.Responses;

namespace Screenshots.Api.Controllers;

[ApiController]
public class ScreenshotsController : ControllerBase
{
    public readonly IMediator _mediator;

    public ScreenshotsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(ApiRoutes.Screenshots.GetScreenshots)]
    public async Task<ActionResult<GetScreenshotsResponse>> Get([FromQuery] GetScreenshotsRequest request,
        CancellationToken token)
    {
        var response = await _mediator.Send(
            new CreateScreenshotsQuery(request.Uri, request.Selector, request.Duration),
            token);

        return Ok(new GetScreenshotsResponse(response.Screenshots));
    }
}
