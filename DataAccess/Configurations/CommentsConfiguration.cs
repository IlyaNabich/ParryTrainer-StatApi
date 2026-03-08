using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class CommentsConfiguration : IEntityTypeConfiguration<CommentsEntity>
{
    public void Configure(EntityTypeBuilder<CommentsEntity> builder)
    {
        builder.HasKey(x => x.ProfileId);
    }
    
}