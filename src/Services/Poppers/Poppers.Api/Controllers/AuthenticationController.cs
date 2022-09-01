using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poppers.Application.Authentication.Command.Login;
using Shared.Poppers.Contracts.V1;
using Shared.Poppers.Contracts.V1.Authentication.Requests;
using Shared.Poppers.Contracts.V1.Authentication.Responses;

namespace Poppers.Api.Controllers;

[ApiController]

public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(ApiRoutes.Authentication.Login)]
    public async Task<IActionResult> Login([FromForm]LoginRequest request)
    {
        var authResult = await _mediator.Send(
            new LoginCommand(request.UserName, request.Password)
        );

        return Ok(new AuthenticationResponse(authResult.AccessToken));
    }
}