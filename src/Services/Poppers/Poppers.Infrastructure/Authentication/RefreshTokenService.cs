using Poppers.Application.Common.Interfaces.Authentication;
using Poppers.Application.Common.Models;
using Poppers.Infrastructure.Persistence.EF.Contexts;

namespace Poppers.Infrastructure.Authentication;

internal sealed class RefreshTokenService : IRefreshTokenService
{
    private readonly ReadDbContext _context;

    public RefreshTokenService(ReadDbContext context)
    {
        _context = context;
    }

    public async Task<RefreshToken> CreateAsync(Guid userId, string ipAddress)
    {
        var token = new RefreshToken()
        {
            Id = Guid.NewGuid(),
            CreateByIp = ipAddress,
            Created = DateTime.UtcNow,
            Expire = DateTime.UtcNow.AddDays(7),
            UserId = userId
        };

        await _context.AddAsync(token);
        await _context.SaveChangesAsync();
        return token;
    }

    public Task<RefreshToken> Refresh(Guid tokenId, string ipAddress)
    {
        throw new NotImplementedException();
    }

    public Task Revoke(Guid tokenId)
    {
        throw new NotImplementedException();
    }
}