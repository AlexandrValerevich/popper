using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Poppers.Application.Common.Models;
using Poppers.Domain.Entities;
using Poppers.Domain.ValueObjects.Gif;
using Poppers.Domain.ValueObjects.User;
using GifDomain = Poppers.Domain.Entities.Gif;

namespace Poppers.Infrastructure.Persistence.EF.Config;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<User>,
    IEntityTypeConfiguration<GifDomain>, IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasConversion(
                id => id.Value,
                id => UserId.From(id)
            );

        builder.Property("_firstName")
            .HasColumnName("FirstName");

        builder.Property("_secondName")
            .HasColumnName("SecondName");

        builder.Property("_passwordHash")
            .HasColumnName("PasswordHash");

        var emailConvertor = new ValueConverter<Email, string>(
            e => e.Value,
            e => new Email(e));
        builder.Property(typeof(Email), "_email")
            .HasConversion(emailConvertor)
            .HasColumnName("Email");

        builder.HasMany<GifDomain>("_gifs");
        builder.Ignore(u => u.Gifs);
    }

    public void Configure(EntityTypeBuilder<GifDomain> builder)
    {
        builder.ToTable("Gifs");

        builder.HasKey(gif => gif.Id);
        builder.Property(u => u.Id)
            .HasConversion(
                id => id.Value,
                id => GifId.From(id));

        var nameConvertor = new ValueConverter<GifName, string>(
            e => e.Value,
            e => new GifName(e));

        builder.Property("_name")
            .HasConversion(nameConvertor)
            .HasColumnName("Name");

        builder.Property<DateTime>("_created")
            .HasColumnName("Created");
    }

    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens");
        builder.HasKey(rt => rt.Id);

        builder.Property(rt => rt.UserId)
            .IsRequired();        
    }
}