using MediatR;

namespace Poppers.Application.Authentication.Queries.Revoke;

public class RevokeQueryHandler
    : IRequestHandler<RevokeQuery>
{
    public Task<Unit> Handle(RevokeQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}