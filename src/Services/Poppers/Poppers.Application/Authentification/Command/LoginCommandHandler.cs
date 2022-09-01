using MediatR;
using Poppers.Application.Authentification.Common;

namespace Poppers.Application.Authentification.Command;

public class LoginCommandHandler 
    : IRequestHandler<LoginCommand, AuthentificationResult>
{
    public Task<AuthentificationResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}