using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poppers.Application.Gif.Commands;
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
    public async Task<IActionResult> Get([FromRoute] GetGifByIdRequest request)
    {
        GifFile response = await _mediator.Send(new GetGifByIdQuery(request.Id));
        return File(response.FileStream, "image/gif");
    }

    [HttpPost(ApiRoutes.Poppers.CreateGif)]
    public async Task<IActionResult> Create([FromBody] CreateGifRequest request)
    {
        var response = await _mediator.Send(new CreateGifCommand()
        {
            Duration = request.Duration,
            ElementSelector = request.Selector,
            Uri = request.Uri
        });

        return CreatedAtAction(nameof(Get),
            new { response.Id },
            new CreateGifResponse(response.Id));
    }

    [HttpDelete(ApiRoutes.Poppers.DeleteGifById)]
    public async Task<IActionResult> Delete([FromRoute] DeleteGifRequest request)
    {
        await _mediator.Send(new DeleteGifCommand(request.Id));
        return Ok();
    }
}
