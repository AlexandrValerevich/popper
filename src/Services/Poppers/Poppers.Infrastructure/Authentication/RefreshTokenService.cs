using System;
using Microsoft.EntityFrameworkCore;
using Poppers.Application.Authentication.Common;
using Poppers.Application.Common.Interfaces.Authentication;
using Poppers.Application.Common.Models;
using Poppers.Infrastructure.Persistence.EF.Contexts;
using Serilog;

namespace Poppers.Infrastructure.Authentication;

internal sealed class RefreshTokenService : IRefreshTokenService
{
    private readonly ReadDbContext _context;
    private DbSet<RefreshToken> RefreshTokens => _context.RefreshTokens;

    public RefreshTokenService(ReadDbContext context)
    {
        _context = context;
    }

    public async Task<RefreshToken> CreateAsync(Guid userId,
        string ipAddress,
        string deviceId,
        CancellationToken cancellationToken)
    {
        var oldRefreshToken = await RefreshTokens.SingleOrDefaultAsync(
            rt => rt.UserId.Equals(userId) && rt.DeviceId.Equals(deviceId),
            cancellationToken);

        if (oldRefreshToken is not null)
        {
            _context.Remove(oldRefreshToken);
        }

        var token = new RefreshToken()
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Created = DateTime.UtcNow,
            Expire = DateTime.UtcNow.AddDays(3),
            CreateByIp = ipAddress,
            DeviceId = deviceId,
            IsRevoked = false
        };

        await _context.AddAsync(token, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return token;
    }

    public async Task<RefreshToken> RefreshAsync(Guid tokenId,
        string ipAddress,
        string deviceId,
        CancellationToken cancellationToken)
    {
        RefreshToken oldRefreshToken = await RefreshTokens.SingleOrDefaultAsync(
            rt => rt.Id.Equals(tokenId) && rt.DeviceId.Equals(deviceId),
            cancellationToken);

        if (oldRefreshToken is null)
        {
            Log.Information("User with ip address: {IpAddress} and deviceId: {DeviceId} tried to use not existed refresh token",
                ipAddress,
                deviceId);
            return null;
        }

        if (oldRefreshToken.IsExpired)
        {
            Log.Information("User with ip address: {IpAddress} and deviceId: {DeviceId} tried to use expired refresh token",
                ipAddress,
                deviceId);
            return null;
        }

        if (oldRefreshToken.IsRevoked)
        {
            Log.Information("User with ip address: {IpAddress} and deviceId: {DeviceId} tried to use revoked refresh token",
                ipAddress,
                deviceId);
            return null;
        }

        var token = new RefreshToken()
        {
            Id = Guid.NewGuid(),
            UserId = oldRefreshToken.UserId,
            Created = DateTime.UtcNow,
            Expire = DateTime.UtcNow.AddDays(3),
            CreateByIp = ipAddress,
            DeviceId = deviceId,
            IsRevoked = false
        };

        _context.Remove(oldRefreshToken);
        await _context.AddAsync(token, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return token;
    }

    public async Task<RefreshTokenRevokeResult> RevokeAsync(Guid tokenId,
        string deviceId,
        CancellationToken cancellationToken)
    {
        RefreshToken refreshToken = await RefreshTokens.SingleOrDefaultAsync(
            rt => rt.Id.Equals(tokenId) && rt.DeviceId.Equals(deviceId),
            cancellationToken);

        if (refreshToken is null)
        {
            return new RefreshTokenRevokeResult(
                false,
                new[] { "Try to revoke unexcited refresh token" });
        }

        if (!refreshToken.IsActive)
        {
            return new RefreshTokenRevokeResult(
                false,
                new[] { "Try to revoke not active refresh token" });
        }

        refreshToken.IsRevoked = true;
        RefreshTokens.Update(refreshToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new RefreshTokenRevokeResult(
            false,
            Array.Empty<string>());
    }
}