using Microsoft.EntityFrameworkCore;
using Poppers.Application.Common.Models;
using Poppers.Domain.Entities;
using Poppers.Infrastructure.Persistence.EF.Config;
using GifDomain = Poppers.Domain.Entities.Gif;

namespace Poppers.Infrastructure.Persistence.EF.Contexts;

internal sealed class WriteDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<GifDomain> Gifs { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("popper");
        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<User>(configuration);
        modelBuilder.ApplyConfiguration<GifDomain>(configuration);
        modelBuilder.ApplyConfiguration<RefreshToken>(configuration);
    }
}