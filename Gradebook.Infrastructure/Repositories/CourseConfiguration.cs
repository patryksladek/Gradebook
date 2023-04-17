using Gradebook.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Gradebook.Infrastructure.Config;

public class CourseConfiguration : BaseEntityConfiguration<Course>
{
    public override void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");

        builder.HasIndex(s => s.Name)
         .IsUnique();
        builder.Property(x => x.Name)
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(200)
            .IsRequired();

        base.Configure(builder);
    }
}

