using MediatR;
using Poppers.Application.Authentification.Common;

namespace Poppers.Application.Authentification.Command;

public class RefreshCommandHandler 
    : IRequestHandler<RefreshCommand, AuthentificationResult>
{
    public Task<AuthentificationResult> Handle(RefreshCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}