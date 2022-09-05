using Poppers.Application.Authentication.Common;
using Poppers.Application.Common.Models;

namespace Poppers.Application.Common.Interfaces.Authentication;

public interface IRefreshTokenService
{
    Task<RefreshToken> CreateAsync(Guid userId, string ipAddress, string deviceId, CancellationToken token);
    Task<RefreshToken> RefreshAsync(Guid tokenId, string ipAddress, string deviceId, CancellationToken token);
    Task<RevokeTokenResult> RevokeAsync(Guid tokenId, string deviceId, CancellationToken token);
}