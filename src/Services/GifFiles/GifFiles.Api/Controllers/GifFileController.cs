using GifFiles.Application.Commands;
using GifFiles.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.GifFile.Contracts.V1;
using Shared.GifFile.Contracts.V1.Requests;
using Shared.GifFile.Contracts.V1.Responses;

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
            new CreateGifCommand(
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
    public async Task<IActionResult> Delete([FromBody] DeleteGifFileByIdRequest request)
    {
        await _mediator.Send(
            new DeleteGifCommand(request.Id)
        );

        return Ok();
    }
}
