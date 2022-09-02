using Poppers.Application.Common.Models;

namespace Poppers.Application.Common.Interfaces.Authentication;

public interface IRefreshTokenService
{
    Task<RefreshToken> Create(Guid userId, string ipAddress);
    Task<RefreshToken> Refresh(Guid id, string ipAddress);
    Task Revoke(Guid tokenId);
}