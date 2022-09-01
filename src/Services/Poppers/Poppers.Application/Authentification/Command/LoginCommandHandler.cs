using MediatR;
using Poppers.Application.Authentification.Common;
using Poppers.Application.Common.Interfaces.Authentification;
using Poppers.Application.Common.Interfaces.Persistence;

namespace Poppers.Application.Authentification.Command;

public class LoginCommandHandler
    : IRequestHandler<LoginCommand, AuthentificationResult>
{
    private readonly IJwtTokenGenerator _jwtGenerator;
    private readonly IUserRepository _userRespository;
    private readonly IPasswordChecker _passwordChecker;

    public LoginCommandHandler(IJwtTokenGenerator jwtGenerator,
        IUserRepository userRespository,
        IPasswordChecker passwordChecker)
    {
        _jwtGenerator = jwtGenerator;
        _userRespository = userRespository;
        _passwordChecker = passwordChecker;
    }

    public async Task<AuthentificationResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        bool isExistedUser = await _userRespository.IsExistedUser(request.UserName, cancellationToken);
        if (!isExistedUser)
        {
            throw new Exception("User Not Found");
        }

        // TODO Geting User by UserName

        if (_passwordChecker.IsCorrectPassword("", ""))
        {
            throw new Exception("Invalid Password");
        }

        var token = _jwtGenerator.Generate(Guid.NewGuid(), "Sasha", "Nesterovich");
        return new AuthentificationResult(token);
    }
}