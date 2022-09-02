using Microsoft.EntityFrameworkCore;
using Poppers.Domain.Entities;
using Poppers.Infrastructure.Persistence.EF.Config;

namespace Poppers.Infrastructure.Persistence.EF.Contexts;

internal sealed class WriteDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("popper");
        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration(configuration);
    }
}