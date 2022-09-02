using MediatR;
using Poppers.Application.Authentication.Common;
using Poppers.Application.Common.Interfaces;
using Poppers.Application.Common.Interfaces.Authentication;
using Poppers.Application.Common.Models;

namespace Poppers.Application.Authentication.Queries.Login;

public class LoginQueryHandler
    : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtGenerator;
    private readonly IUserReader _userReader;
    private readonly IPasswordValidator _passwordChecker;
    private readonly IRefreshTokenService _refreshTokenService;

    public LoginQueryHandler(IJwtTokenGenerator jwtGenerator,
        IUserReader userReader,
        IPasswordValidator passwordChecker,
        IRefreshTokenService refreshTokenService)
    {
        _jwtGenerator = jwtGenerator;
        _userReader = userReader;
        _passwordChecker = passwordChecker;
        _refreshTokenService = refreshTokenService;
    }

    public async Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        UserReadOnlyModel user = await _userReader.GetUserByEmail(request.Email, cancellationToken);
        if (user is null)
        {
            throw new Exception($"User with email {request.Email} not exist");
        }

        if (!_passwordChecker.IsValid(user.PasswordHash, request.Password))
        {
            throw new Exception("Invalid Password");
        }

        string accessToken = _jwtGenerator.Generate(user.Id, user.FirstName, user.SecondName);
        RefreshToken refreshToken = await _refreshTokenService.CreateAsync(user.Id, request.IpAddress);
        return new AuthenticationResult(accessToken, refreshToken.Id.ToString());
    }
}