using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poppers.Application.Gif.Commands.CreateGif;
using Poppers.Application.Gif.Commands.DeleteGif;
using Poppers.Application.Gif.Common;
using Poppers.Application.Gif.Queries;
using Shared.Poppers.Contracts.V1;
using Shared.Poppers.Contracts.V1.Requests;
using Shared.Poppers.Contracts.V1.Responses;

namespace Poppers.Api.Controllers;

[ApiController]
public class PoppersController : ControllerBase
{
    private readonly IMediator _mediator;

    public PoppersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(ApiRoutes.Poppers.GetGifById)]
    public async Task<IActionResult> Get([FromRoute] GetGifByIdRequest request,
        CancellationToken token)
    {
        GifFile response = await _mediator.Send(new GetGifByIdQuery(request.Id), token);
        return File(response.FileStream, "image/gif");
    }

    [HttpPost(ApiRoutes.Poppers.CreateGif)]
    public async Task<IActionResult> Create([FromBody] CreateGifRequest request,
        CancellationToken token)
    {
        var response = await _mediator.Send(new CreateGifCommand()
        {
            Duration = request.Duration,
            ElementSelector = request.Selector,
            Uri = request.Uri
        }, token);

        return CreatedAtAction(nameof(Get),
            new { response.Id },
            new CreateGifResponse(response.Id));
    }

    [HttpDelete(ApiRoutes.Poppers.DeleteGifById)]
    public async Task<IActionResult> Delete([FromRoute] DeleteGifRequest request,
        CancellationToken token)
    {
        await _mediator.Send(new DeleteGifCommand(request.Id), token);
        return Ok();
    }
}
