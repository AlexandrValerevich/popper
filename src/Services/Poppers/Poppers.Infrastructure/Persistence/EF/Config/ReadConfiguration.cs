using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poppers.Application.Common.Models;

namespace Poppers.Infrastructure.Persistence.EF.Config;

internal sealed class ReadConfiguration : IEntityTypeConfiguration<UserReadOnlyModel>
{
    public void Configure(EntityTypeBuilder<UserReadOnlyModel> builder)
    {
        builder.ToTable("User");
        builder.HasKey(u => u.Id);
    }
}