using MediatR;
using Poppers.Application.Authentication.Common;
using Poppers.Application.Common.Interfaces.Authentication;
using Poppers.Application.Common.Interfaces.Persistence;

namespace Poppers.Application.Authentication.Command.Login;

public class LoginQueryHandler
    : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtGenerator;
    private readonly IUserService _userRepository;
    private readonly IPasswordChecker _passwordChecker;

    public LoginQueryHandler(IJwtTokenGenerator jwtGenerator,
        IUserService userRepository,
        IPasswordChecker passwordChecker)
    {
        _jwtGenerator = jwtGenerator;
        _userRepository = userRepository;
        _passwordChecker = passwordChecker;
    }

    public async Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        bool isExistedUser = await _userRepository.IsExistedUser(request.UserName, cancellationToken);
        if (!isExistedUser)
        {
            throw new Exception("User Not Found");
        }

        // TODO Getting User by UserName

        if (!_passwordChecker.IsCorrectPassword("", ""))
        {
            throw new Exception("Invalid Password");
        }

        var token = _jwtGenerator.Generate(Guid.NewGuid(), "Sasha", "Nesterovich");
        return new AuthenticationResult(token);
    }
} 