using MediatR;
using Poppers.Application.Authentication.Common;
using Poppers.Application.Common.Exceptions.Authentication;
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

    public async Task<AuthenticationResult> Handle(LoginQuery request,
        CancellationToken cancellationToken)
    {
        UserReadOnlyModel user = await TryReadUser(request.Email, cancellationToken);
        ValidatePassword(user.PasswordHash, request.Password);

        string accessToken = _jwtGenerator.Generate(user.Id, user.FirstName, user.SecondName);
        RefreshToken refreshToken = await _refreshTokenService.CreateAsync(user.Id,
            request.IpAddress,
            request.DeviceId,
            cancellationToken);

        return new AuthenticationResult(accessToken, refreshToken.Id.ToString());
    }


    private async Task<UserReadOnlyModel> TryReadUser(string email, CancellationToken cancellationToken)
    {
        UserReadOnlyModel user = await _userReader.ReadByEmail(email, cancellationToken);
        if (user is null)
        {
            throw new NotFoundUserException(email);
        }

        return user;
    }

    private void ValidatePassword(string passwordHash, string password)
    {
        if (!_passwordChecker.IsValid(passwordHash, password))
        {
            throw new IncorrectPasswordException();
        }
    }
}