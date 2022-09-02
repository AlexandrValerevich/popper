using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poppers.Application.Common.Models;

namespace Poppers.Infrastructure.Persistence.EF.Config;

internal sealed class ReadConfiguration : IEntityTypeConfiguration<UserReadOnlyModel>,
        IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<UserReadOnlyModel> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
    }

    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens");
        builder.HasKey(rt => rt.Id);

        builder.HasOne<UserReadOnlyModel>()
            .WithMany()
            .HasForeignKey(rt => rt.UserId);
    }
}