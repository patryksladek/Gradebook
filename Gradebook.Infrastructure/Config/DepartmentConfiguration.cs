using Gradebook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gradebook.Infrastructure.Config;

public class DepartmentConfiguration : BaseEntityConfiguration<Department>
{
    public override void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments");

        builder.HasIndex(s => s.Name)
         .IsUnique();
        builder.Property(x => x.Name)
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(x => x.Building)
            .HasMaxLength(8)
            .IsRequired();

        builder.HasMany(d => d.Students)
           .WithOne(s => s.Department)
           .HasForeignKey(s => s.DepartmentId);

        base.Configure(builder);
    }
}
