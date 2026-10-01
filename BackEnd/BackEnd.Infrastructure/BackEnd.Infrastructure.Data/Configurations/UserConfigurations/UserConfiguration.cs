using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BackEnd.Domain.Entities.User;
using BackEnd.Infrastructure.Core.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using BackEnd.Domain.Common.Enums;


namespace BackEnd.Infrastructure.Data.Configurations.UserConfigurations;

public sealed class UserConfiguration : EntityConfiguration<User>
{
    protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CreateAt)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UpdateAt)
            .IsRequired(false);

        builder.Property(x => x.RecordStatus)
            .IsRequired()
            .HasDefaultValue(RecordStatus.Active);

        builder.Property(x => x.UserName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.PasswordHash)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.UserType)
            .IsRequired();
    }
}
