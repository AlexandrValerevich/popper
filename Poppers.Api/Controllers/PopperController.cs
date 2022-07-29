using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poppers.Application.Gif.Commands;
using Poppers.Application.Gif.Common;
using Poppers.Contracts.V1.Requests;

namespace Poppers.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PopperController : ControllerBase
{
    private readonly IMediator _mediator;

    public PopperController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]GifCreateRequest request)
    {
        GifFile response = await _mediator.Send(new GifCreateCommand()
        {
            Delay = request.Delay,
            Duration = request.Duration,
            ElementSelector = request.Selector,
            Uri = request.Uri
        });

        return File(response.FileStream, "image/gif");
    }
}
