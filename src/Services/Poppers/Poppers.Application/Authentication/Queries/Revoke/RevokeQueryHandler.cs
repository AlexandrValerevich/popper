using System.Text;
using MediatR;
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
        var revokeResult = await _refreshTokenService.RevokeAsync(request.RefreshToken,
            request.DeviceId,
            cancellationToken);

        if (!revokeResult.IsSuccess)
        {
            var errors = new StringBuilder();
            errors.AppendJoin("; ", revokeResult.Errors);
            throw new Exception(errors.ToString());
        }
        
        return Unit.Value;
    }
}