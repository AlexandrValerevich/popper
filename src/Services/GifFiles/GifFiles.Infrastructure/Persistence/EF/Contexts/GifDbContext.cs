using GifFiles.Application.Common;
using Microsoft.EntityFrameworkCore;
using Poppers.Infrastructure.Persistence.EF.Config;

namespace Poppers.Infrastructure.Persistence.EF.Contexts;

internal sealed class GifDbContext : DbContext
{
    public DbSet<Gif> Gifs { get; set; }

    public GifDbContext(DbContextOptions<GifDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("gif");
        var configuration = new GifConfiguration();
        modelBuilder.ApplyConfiguration(configuration);
    }
}