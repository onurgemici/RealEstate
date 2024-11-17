using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace RealEstateData;

public class Specification
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
}

public class SpecificationEntityTypeConfiguration : IEntityTypeConfiguration<Specification>
{
    public void Configure(EntityTypeBuilder<Specification> builder)
    {
        builder
            .HasIndex(p => new { p.Name })
            .IsUnique();

        builder
            .Property(p => p.Name)
            .HasMaxLength(400)
            .IsRequired();
        builder
      .HasData(
      new Specification { Id = Guid.Parse("{4DC44B8B-B92A-4F3A-99AF-874352121B6E}"), Name = "Kombili" },
      new Specification { Id = Guid.Parse("{46A1FC19-0732-4F76-B087-EFFEB11AAA62}"), Name = "Fiber İnternet" },
      new Specification { Id = Guid.Parse("{767B3607-9B58-4404-86CF-311D676E71B6}"), Name = "Havuzlu" },
      new Specification { Id = Guid.Parse("{FD516F5B-7983-41DF-9D54-6435F02402E6}"), Name = "Güvenlik" },
      new Specification { Id = Guid.Parse("{30999148-EA38-4C31-B789-8ED39CFB5EC1}"), Name = "Deniz Manzaralı" },
      new Specification { Id = Guid.Parse("{5A8CE8A7-D59A-428C-BE14-A7CD74DCB97B}"), Name = "Kapalı Otopark" },
      new Specification { Id = Guid.Parse("{6F5F1DCB-E5E0-45A3-9464-D15232E89FCA}"), Name = "Yerden Isıtma" },
      new Specification { Id = Guid.Parse("{B1DF6E21-5567-47A2-B1EA-01BAF93891A4}"), Name = "Merkezi Isıtma" },
      new Specification { Id = Guid.Parse("{A7F92A4D-8EC5-4619-B3FD-821228241CE4}"), Name = "Cam balkon" },
      new Specification { Id = Guid.Parse("{2BBB9C72-F34B-488B-99FB-EB84DB730CA3}"), Name = "Teras" },
      new Specification { Id = Guid.Parse("{3ECA8670-2FB4-419D-B97E-8B6228EA553F}"), Name = "Ebeveyn Banyo" }
      );
    }
}