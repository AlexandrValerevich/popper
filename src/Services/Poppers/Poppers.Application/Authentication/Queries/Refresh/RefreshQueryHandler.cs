using MediatR;
using Poppers.Application.Authentication.Common;
using Poppers.Application.Common.Interfaces;
using Poppers.Application.Common.Interfaces.Authentication;
using Poppers.Application.Common.Models;

namespace Poppers.Application.Authentication.Command.Refresh;

public class RefreshQueryHandler
    : IRequestHandler<RefreshQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtGenerator;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly IUserReader _userReader;

    public RefreshQueryHandler(IJwtTokenGenerator jwtGenerator,
        IRefreshTokenService refreshTokenService,
        IUserReader userReader)
    {
        _jwtGenerator = jwtGenerator;
        _refreshTokenService = refreshTokenService;
        _userReader = userReader;
    }

    public async Task<AuthenticationResult> Handle(RefreshQuery request, 
        CancellationToken cancellationToken)
    {
        RefreshToken refreshToken = await _refreshTokenService.RefreshAsync(
            request.RefreshToken,
            request.IpAddress,
            request.DeviceId,
            cancellationToken);

        if (refreshToken is null)
        {
            throw new Exception("Try to refresh invalid refresh token");
        }

        var user = await _userReader.ReadById(refreshToken.UserId, cancellationToken);
        var accessToken = _jwtGenerator.Generate(user.Id, 
            user.FirstName, 
            user.SecondName);

        return new AuthenticationResult(accessToken, refreshToken.Id.ToString());
    }
}