using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateData;

public class PostImage
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
    public required string Image { get; set; }
    public virtual Post? Post { get; set; }

}
public class PostImageEntityTypeConfiguration : IEntityTypeConfiguration<PostImage>
{
    public void Configure(EntityTypeBuilder<PostImage> builder)
    {
        builder
            .Property(p => p.Image)
            .IsUnicode(false)
            .IsRequired();
    }
}
