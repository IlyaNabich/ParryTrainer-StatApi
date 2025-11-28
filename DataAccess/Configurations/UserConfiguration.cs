using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<UsersEntity>
{
    public void Configure(EntityTypeBuilder<UsersEntity> builder)
    {
        builder
            .HasKey(x => x.UserId);

        builder
            .HasOne(x => x.StatsEntity)
            .WithOne(x => x.UsersEntity)
            .HasForeignKey<StatsEntity>(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.ProfilesEntity)
            .WithOne(x => x.UsersEntity)
            .HasForeignKey<ProfilesEntity>(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.Login)
            .HasColumnName("Login")
            .HasMaxLength(60)
            .IsRequired();
        
        builder.Property(x => x.UserName)
            .HasColumnName("UserName")
            .HasMaxLength(60)
            .IsRequired();
    }
}