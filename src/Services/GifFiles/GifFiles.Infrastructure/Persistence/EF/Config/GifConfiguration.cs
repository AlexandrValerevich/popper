using GifFiles.Application.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Poppers.Infrastructure.Persistence.EF.Config;

internal sealed class GifConfiguration : IEntityTypeConfiguration<Gif>
{
    public void Configure(EntityTypeBuilder<Gif> builder)
    {
        builder.ToTable("Gifs");
        builder.HasKey(g => new {g.Id, g.UserId});
    }
}