using Microsoft.EntityFrameworkCore;
using Poppers.Application.Common.Models;
using Poppers.Infrastructure.Persistence.EF.Config;

namespace Poppers.Infrastructure.Persistence.EF.Contexts;

internal sealed class ReadDbContext : DbContext
{
    public DbSet<UserReadOnlyModel> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("popper");
        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<UserReadOnlyModel>(configuration);
        modelBuilder.ApplyConfiguration<RefreshToken>(configuration);
    }
}