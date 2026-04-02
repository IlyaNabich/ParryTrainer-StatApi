using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class StatsConfiguration : IEntityTypeConfiguration<StatsEntity>
{
    public void Configure(EntityTypeBuilder<StatsEntity> builder)
    {
        builder
            .HasKey(e => e.UserId);
        
    }
}