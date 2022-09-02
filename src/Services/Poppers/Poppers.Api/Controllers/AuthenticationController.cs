using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poppers.Application.Authentication.Command.Login;
using Poppers.Application.Authentication.Command.Registration;
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
            new LoginQuery(request.Email, request.Password)
        );

        return Ok(new AuthenticationResponse(authResult.AccessToken));
    }

    [HttpPost(ApiRoutes.Authentication.Registration)]
    public async Task<IActionResult> Registration([FromForm]RegistrationRequest request)
    {
        var authResult = await _mediator.Send(
            new RegistrationCommand(request.FirstName,
                request.SecondName,
                request.Email,
                request.Password)
        );

        return Ok(new AuthenticationResponse(authResult.AccessToken));
    }
}