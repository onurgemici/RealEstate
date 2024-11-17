using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RealEstateData;

public class Category
{
    public Guid Id { get; set; }

    public required string Name { get; set; }
    public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();

}

public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .HasIndex(p => p.Name)
            .IsUnique();
        builder
             .Property(p => p.Name)
             .IsRequired()
             .HasMaxLength(400);
        builder
            .HasMany(p => p.Posts)
            .WithOne(p => p.Category)
            .HasForeignKey(p=> p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
            

    }
}
