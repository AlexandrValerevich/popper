using GifFiles.Application.Common;
using GifFiles.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Poppers.Infrastructure.Persistence.EF.Contexts;

namespace GifFiles.Infrastructure.Persistence;

internal sealed class GifWriter : IGifWriter
{
    private readonly GifDbContext _context;

    public GifWriter(GifDbContext context)
    {
        _context = context;
    }
    private DbSet<Gif> Gifs => _context.Gifs;


    public async Task CreateAsync(Gif gif, CancellationToken token)
    {
        await Gifs.AddAsync(gif, token);
        await _context.SaveChangesAsync(token);
    }

    public async Task DeleteAllByUserIdAsync(Guid userId, CancellationToken token)
    {
        var gifs = await Gifs.Where(gif => gif.UserId.Equals(userId)).ToArrayAsync(token);
        Gifs.RemoveRange(gifs);
        await _context.SaveChangesAsync(token);
    }

    public async Task DeleteByIdAsync(Guid gifId, Guid userId, CancellationToken token)
    {
        var gif = await Gifs.SingleOrDefaultAsync(
            g => g.UserId.Equals(userId) && g.Id.Equals(gifId),
            token);
        Gifs.Remove(gif);
        await _context.SaveChangesAsync(token);
    }

    public async Task UpdateAsync(Gif gif, CancellationToken token)
    {
        Gifs.Update(gif);
        await _context.SaveChangesAsync(token);
    }
}