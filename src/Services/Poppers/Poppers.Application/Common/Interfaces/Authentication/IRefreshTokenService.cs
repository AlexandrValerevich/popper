using Poppers.Application.Common.Models;

namespace Poppers.Application.Common.Interfaces.Authentication;

public interface IRefreshTokenService
{
    Task<RefreshToken> CreateAsync(Guid userId, string ipAddress, string deviceId, CancellationToken token);
    Task<RefreshToken> Refresh(Guid tokenId, string ipAddress, string deviceId, CancellationToken token);
    Task Revoke(Guid tokenId, CancellationToken token);
}