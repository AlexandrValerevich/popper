using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.GifFiles.Contracts.V1.Responses;
using Shared.GifFiles.Contracts.V1;
using Shared.GifFiles.Contracts.V1.Requests;
using GifFiles.Application.Commands.DeleteGifFile;
using GifFiles.Application.Queries.GetGifFileById;
using GifFiles.Application.Commands.CreateGif;
using GifFiles.Application.Common;

namespace GifFiles.Api.Controllers;

[ApiController]
public class GifFilesController : ControllerBase
{
    private readonly IMediator _mediator;

    public GifFilesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(ApiRoutes.GifFile.GetGifFileById)]
    public async Task<IActionResult> Get([FromRoute] GetGifByIdRequest request,
        CancellationToken token)
    {
        var gifFile = await _mediator.Send(
            new GetGifFileByIdQuery(request.GifId, request.UserId),
            token);

        return File(gifFile.Stream, "image/gif");
    }

    [HttpPost(ApiRoutes.GifFile.CreateGifFile)]
    public async Task<IActionResult> Create([FromBody] CreateGifRequest request,
        CancellationToken token)
    {
        GifCreationResult gifCreationResult = await _mediator.Send(
            new CreateGifCommand(
                request.UserId,
                request.Name,
                request.Delay,
                request.Images
            ),
            token);

        return CreatedAtAction(
            nameof(GifFilesController.Get),
            new { request.UserId, gifCreationResult.GifId },
            new CreateGifFileResponse(gifCreationResult.GifId));
    }

    [HttpDelete(ApiRoutes.GifFile.DeleteGifFile)]
    public async Task<IActionResult> Delete([FromRoute] DeleteGifByIdRequest request,
        CancellationToken token)
    {
        await _mediator.Send(
            new DeleteGifByIdCommand(request.GifId, request.UserId),
            token
        );

        return Ok();
    }
}
