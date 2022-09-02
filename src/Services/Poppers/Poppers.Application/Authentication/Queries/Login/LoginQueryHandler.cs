using MediatR;
using Poppers.Application.Authentication.Common;
using Poppers.Application.Common.Interfaces;
using Poppers.Application.Common.Interfaces.Authentication;

namespace Poppers.Application.Authentication.Queries.Login;

public class LoginQueryHandler
    : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtGenerator;
    private readonly IUserReader _userReader;
    private readonly IPasswordValidator _passwordChecker;

    public LoginQueryHandler(IJwtTokenGenerator jwtGenerator,
        IUserReader userReader,
        IPasswordValidator passwordChecker)
    {
        _jwtGenerator = jwtGenerator;
        _userReader = userReader;
        _passwordChecker = passwordChecker;
    }

    public async Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userReader.GetUserByEmail(request.Email, cancellationToken);
        if (user is null)
        {
            throw new Exception($"User with email {request.Email} not exist");
        }

        if (!_passwordChecker.IsValid(user.PasswordHash, request.Password))
        {
            throw new Exception("Invalid Password");
        }

        var token = _jwtGenerator.Generate(user.Id, user.FirstName, user.SecondName);
        return new AuthenticationResult(token);
    }
}