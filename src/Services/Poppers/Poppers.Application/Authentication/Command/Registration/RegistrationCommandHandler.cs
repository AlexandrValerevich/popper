using MediatR;
using Poppers.Application.Authentication.Common;

namespace Poppers.Application.Authentication.Command.Registration;

public class RegistrationCommandHandler
    : IRequestHandler<RegistrationCommand, AuthenticationResult>
{
    public Task<AuthenticationResult> Handle(RegistrationCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}