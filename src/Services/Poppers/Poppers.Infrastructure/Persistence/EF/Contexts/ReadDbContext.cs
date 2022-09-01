using Microsoft.EntityFrameworkCore;
using Poppers.Application.Common.Models;
using Poppers.Infrastructure.Persistence.EF.Config;

namespace Poppers.Infrastructure.Persistence.EF.Contexts;

internal sealed class ReadDbContext : DbContext
{
    public DbSet<UserReadOnlyModel> PackingLists { get; set; }

    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("popper");
        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration(configuration);
    }
}