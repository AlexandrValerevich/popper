using Poppers.Application.Gif.Common;
using Poppers.Application.Common.Interfaces.Persistence;
using Poppers.Infrastructure.Persistence.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Poppers.Infrastructure.Persistence;

internal sealed class GifReader : IGifReader
{
    private readonly ReadDbContext _context;
    private DbSet<GifReadOnlyModel> Gifs => _context.Gifs;

    public GifReader(ReadDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GifReadOnlyModel>> ReadAllUserGifsAsync(Guid userId, CancellationToken token)
    {
        return await Gifs.Where(g => g.UserId.Equals(userId))
            .AsNoTracking()
            .ToArrayAsync(token);
    }
}