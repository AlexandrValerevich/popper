using GifFiles.Application.Common;
using GifFiles.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Poppers.Infrastructure.Persistence.EF.Contexts;

namespace GifFiles.Infrastructure.Persistence;

internal sealed class GifReader : IGifReader
{
    private readonly GifDbContext _context;

    public GifReader(GifDbContext context)
    {
        _context = context;
    }

    private DbSet<Gif> Gifs => _context.Gifs;

    public async Task<IEnumerable<Gif>> ReadAllAsync(Guid userId, CancellationToken token)
    {
        return await Gifs.Where(gif => gif.UserId.Equals(userId))
            .AsNoTracking()
            .ToArrayAsync(token);
    }
}