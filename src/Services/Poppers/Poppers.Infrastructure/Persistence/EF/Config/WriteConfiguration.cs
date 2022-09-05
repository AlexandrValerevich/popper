using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Poppers.Domain.Entities;
using Poppers.Domain.ValueObjects.User;

namespace Poppers.Infrastructure.Persistence.EF.Config;

public class WriteConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasConversion(id => id.Value, id => id);

        builder.Property("_firstName")
            .HasColumnName("FirstName");

        builder.Property("_secondName")
            .HasColumnName("SecondName");

        builder.Property("_passwordHash")
            .HasColumnName("PasswordHash");

        var EmailConvertor = new ValueConverter<Email, string>(e => e.Value,
            e => new Email(e));

        builder.Property(typeof(Email), "_email")
            .HasConversion(EmailConvertor)
            .HasColumnName("Email");
    }
}