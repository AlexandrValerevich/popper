using MediatR;
using Poppers.Application.Authentification.Common;

namespace Poppers.Application.Authentification.Command;

public class RegistrationCommandHandler 
    : IRequestHandler<RegistrationCommand, AuthentificationResult>
{
    public Task<AuthentificationResult> Handle(RegistrationCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}