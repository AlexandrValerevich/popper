using System.Text;
using MediatR;
using Poppers.Application.Authentication.Common;
using Poppers.Application.Common.Exceptions.Authentication;
using Poppers.Application.Common.Interfaces.Authentication;

namespace Poppers.Application.Authentication.Queries.Revoke;

public class RevokeQueryHandler
    : IRequestHandler<RevokeQuery>
{
    private readonly IRefreshTokenService _refreshTokenService;

    public RevokeQueryHandler(IRefreshTokenService refreshTokenService)
    {
        _refreshTokenService = refreshTokenService;
    }

    public async Task<Unit> Handle(RevokeQuery request, CancellationToken cancellationToken)
    {
        RevokeResult revokeResult = await _refreshTokenService.RevokeAsync(request.RefreshToken,
            request.DeviceId,
            cancellationToken);

        if (!revokeResult.IsSuccess)
        {
            var errors = new StringBuilder();
            errors.AppendJoin("; ", revokeResult.Errors);
            throw new InvalidRevokeException(errors.ToString());
        }

        return Unit.Value;
    }
}