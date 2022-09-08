using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Poppers.Application.Gif.Commands.CreateGif;
using Poppers.Application.Gif.Commands.DeleteGif;
using Poppers.Application.Gif.Common;
using Poppers.Application.Gif.Queries;
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
    public async Task<IActionResult> Get([FromRoute] GetGifByIdRequest request,
        CancellationToken token)
    {
        GifFile response = await _mediator.Send(
            new GetGifByIdQuery(request.Id, UserId),
            token);

        return File(response.FileStream, "image/gif");
    }

    [HttpPost(ApiRoutes.Poppers.CreateGif)]
    public async Task<IActionResult> Create([FromBody] CreateGifRequest request,
        CancellationToken token)
    {
        var response = await _mediator.Send(
            new CreateGifCommand(
                UserId,
                request.Duration,
                request.Selector,
                request.Uri,
                request.Name),
            token);

        return CreatedAtAction(nameof(Get),
            new { response.Id },
            new CreateGifResponse(response.Id));
    }

    [HttpDelete(ApiRoutes.Poppers.DeleteGifById)]
    public async Task<IActionResult> Delete([FromRoute] DeleteGifRequest request,
        CancellationToken token)
    {
        await _mediator.Send(
            new DeleteGifCommand(request.Id, UserId),
            token);

        return Ok();
    }

    private Guid UserId => Guid.Parse(
        HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
}
