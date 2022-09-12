using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Poppers.Application.Gif.Commands.CreateGif;
using Poppers.Application.Gif.Commands.DeleteAllUserGifs;
using Poppers.Application.Gif.Commands.DeleteGif;
using Poppers.Application.Gif.Common;
using Poppers.Application.Gif.Queries.GetGifById;
using Shared.Poppers.Contracts.V1;
using Shared.Poppers.Contracts.V1.Gif.Requests;
using Shared.Poppers.Contracts.V1.Gif.Responses;

namespace Poppers.Api.Controllers;

[Authorize]
[ApiController]
public class PoppersController : ControllerBase
{
    private readonly IMediator _mediator;

    public PoppersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(ApiRoutes.Poppers.GetGifById)]
    public async Task<IActionResult> Get([FromRoute] Guid gifId,
        CancellationToken token)
    {
        GifFile response = await _mediator.Send(
            new GetGifByIdQuery(gifId, UserId),
            token);

        return File(response.FileStream, "image/gif");
    }

    [HttpGet(ApiRoutes.Poppers.GetAllUserPoppersById)]
    public async Task<IActionResult> GetAllUserPoppers(CancellationToken token)
    {
        IEnumerable<GifReadOnlyModel> gifs = await _mediator.Send(
            new GetAllUserGifsQuery(UserId),
            token);

        return Ok(gifs);
    }

    [HttpPost(ApiRoutes.Poppers.CreateGif)]
    public async Task<IActionResult> Create([FromBody] CreateGifRequest request,
        CancellationToken token)
    {
        GifCreationResult response = await _mediator.Send(
            new CreateGifCommand(
                UserId,
                request.Duration,
                request.Selector,
                request.Uri,
                request.Name),
            token);

        return CreatedAtAction(nameof(Get),
            new { response.GifId },
            new CreateGifResponse(response.GifId));
    }

    [HttpDelete(ApiRoutes.Poppers.DeleteGifById)]
    public async Task<IActionResult> Delete([FromRoute] Guid gifId,
        CancellationToken token)
    {
        await _mediator.Send(
            new DeleteGifCommand(gifId, UserId),
            token);

        return Ok();
    }

    [HttpDelete(ApiRoutes.Poppers.DeleteAllUserGifs)]
    public async Task<IActionResult> DeleteAllUserGifs(CancellationToken token)
    {
        await _mediator.Send(
            new DeleteAllUserGifsCommand(UserId),
            token);

        return Ok();
    }

    private Guid UserId => Guid.Parse(
        HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
}
