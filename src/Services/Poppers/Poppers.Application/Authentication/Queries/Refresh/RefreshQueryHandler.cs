using MediatR;
using Poppers.Application.Authentication.Common;

namespace Poppers.Application.Authentication.Command.Refresh;

public class RefreshQueryHandler
    : IRequestHandler<RefreshCommand, AuthenticationResult>
{
    public Task<AuthenticationResult> Handle(RefreshCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}