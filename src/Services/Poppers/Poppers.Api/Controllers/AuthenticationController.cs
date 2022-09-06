using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Poppers.Api.Http;
using Poppers.Application.Authentication.Command.Registration;
using Poppers.Application.Authentication.Queries.Login;
using Poppers.Application.Authentication.Queries.Refresh;
using Poppers.Application.Authentication.Queries.Revoke;
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
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var authResult = await _mediator.Send(
            new LoginQuery(request.Email,
            request.Password,
            IpAddress(),
            request.DeviceId)
        );

        AddRefreshTokenToCookie(authResult.RefreshToken);
        return Ok(new AuthenticationResponse(authResult.AccessToken));
    }

    [HttpPost(ApiRoutes.Authentication.Registration)]
    public async Task<IActionResult> Registration([FromBody] RegistrationRequest request,
        CancellationToken token)
    {
        var authResult = await _mediator.Send(
            new RegistrationCommand(request.FirstName,
                request.SecondName,
                request.Email,
                request.Password,
                IpAddress(),
                request.DeviceId), token
        );

        AddRefreshTokenToCookie(authResult.RefreshToken);
        return Ok(new AuthenticationResponse(authResult.AccessToken));
    }

    [Authorize]
    [HttpPost(ApiRoutes.Authentication.Refresh)]
    public async Task<IActionResult> Refresh([FromBody] RefreshRequest request,
        CancellationToken token)
    {
        var authResult = await _mediator.Send(
            new RefreshQuery(Guid.Parse(RefreshToken), IpAddress(), request.DeviceId),
            token);

        AddRefreshTokenToCookie(authResult.RefreshToken);
        return Ok(new AuthenticationResponse(authResult.AccessToken));
    }

    [Authorize]
    [HttpPost(ApiRoutes.Authentication.Revoke)]
    public async Task<IActionResult> Revoke([FromBody] RevokeRequest request,
       CancellationToken token)
    {
        await _mediator.Send(
            new RevokeQuery(Guid.Parse(RefreshToken), request.DeviceId),
            token);

        return Ok();
    }

    private string RefreshToken => Request.Cookies[HttpCookiesKeys.RefreshToken];

    private void AddRefreshTokenToCookie(string refreshToken)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(7)
        };

        Response.Cookies.Append(HttpCookiesKeys.RefreshToken, refreshToken, cookieOptions);
    }

    private string IpAddress()
    {
        return Request.Headers.ContainsKey("X-Forwarded-For")
            ? (string)Request.Headers["X-Forwarded-For"]
            : HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
    }
}