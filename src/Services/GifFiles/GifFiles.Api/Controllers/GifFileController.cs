using GifFiles.Application.Commands;
using GifFiles.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.GifFiles.Contracts.V1.Responses;
using Shared.GifFiles.Contracts.V1;
using Shared.GifFiles.Contracts.V1.Requests;

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
    public async Task<IActionResult> Get([FromRoute] GetGifFileByIdRequest request)
    {
        var gifFile = await _mediator.Send(
            new GetGifFileByIdQuery(request.Id)
        );

        return File(gifFile.Stream, "image/gif");
    }

    [HttpPost(ApiRoutes.GifFile.CreateGifFile)]
    public async Task<IActionResult> Create([FromBody] CreateGifFileRequest request)
    {
        var gifCreationResult = await _mediator.Send(
            new CreateGifFileCommand(
                request.Id,
                request.Images,
                request.Delay
            )
        );

        return CreatedAtAction(
            nameof(GifFilesController.Get),
            new { gifCreationResult.Id },
            new CreateGifResponse(gifCreationResult.Id));
    }

    [HttpDelete(ApiRoutes.GifFile.DeleteGifFile)]
    public async Task<IActionResult> Delete([FromRoute] DeleteGifFileByIdRequest request)
    {
        await _mediator.Send(
            new DeleteGifFileCommand(request.Id)
        );

        return Ok();
    }
}
