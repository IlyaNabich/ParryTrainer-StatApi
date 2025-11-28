using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<ProfilesEntity>
{
    public void Configure(EntityTypeBuilder<ProfilesEntity> builder)
    {
        builder
            .HasKey(x => x.UserId);
        
        builder
            .HasMany(x => x.CommentsEntity)
            .WithOne(x => x.ProfilesEntity)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .Property(x => x.FirstName)
            .HasColumnName("FirstName")
            .HasMaxLength(50);
        
        builder
            .Property(x => x.LastName)
            .HasColumnName("LastName")
            .HasMaxLength(50);

        builder
            .Property(x => x.Age)
            .HasColumnName("Age")
            .HasMaxLength(3);

        builder
            .Property(x => x.Country)
            .HasColumnName("Country");
        
        builder
            .Property(x => x.Description)
            .HasColumnName("Description")
            .HasMaxLength(500);

        builder
            .Property(x => x.Region)
            .HasColumnName("Region");
        
        


    }
}