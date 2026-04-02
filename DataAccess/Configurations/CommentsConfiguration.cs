using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class CommentsConfiguration : IEntityTypeConfiguration<CommentsEntity>
{
    public void Configure(EntityTypeBuilder<CommentsEntity> builder)
    {
        builder.HasKey(x => x.CommentId);
        
        builder.Property(x => x.CommentId)
            .ValueGeneratedOnAdd(); 
        
        builder.HasIndex(x => x.ProfileId);
    }
}
