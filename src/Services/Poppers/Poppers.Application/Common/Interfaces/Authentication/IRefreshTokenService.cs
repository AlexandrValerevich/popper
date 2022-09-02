using Poppers.Application.Common.Models;

namespace Poppers.Application.Common.Interfaces.Authentication;

public interface IRefreshTokenService
{
    Task<RefreshToken> CreateAsync(Guid userId, string ipAddress);
    Task<RefreshToken> Refresh(Guid tokenId, string ipAddress);
    Task Revoke(Guid tokenId);
}