using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace RealEstateData;

public enum PostTypes
{
    ForSale, ForRent
}

public class Post
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public int DistrictId { get; set; }

    public Guid CategoryId { get; set; }

    public required string Name { get; set; }



    public string? Image { get; set; }

    public string? Descriptions { get; set; }

    public decimal Price { get; set; }

    public DateTime Date { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public PostTypes Type { get; set; }

    public virtual User? User { get; set; }
    public virtual District? District { get; set; }
    public virtual Category? Category { get; set;}
    public virtual ICollection<PostImage> PostImages { get; set; } = new HashSet<PostImage>();

    public virtual ICollection<Specification> Specifications { get; set; } = new HashSet<Specification>();

}

public class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder
            .HasIndex(p => new { p.Name })
            .IsUnique(false);

        builder
            .Property(p => p.Name)
            .HasMaxLength(400)
            .IsRequired();

        builder
            .HasMany(p => p.PostImages)
            .WithOne(p => p.Post)
            .HasForeignKey(p => p.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(p => p.Price)
            .HasPrecision(18, 4);

        builder
            .Property(p => p.Image)
            .IsUnicode(false);
       
    }

}