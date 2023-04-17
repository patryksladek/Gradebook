using Gradebook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gradebook.Infrastructure.Config;

public class GradeConfiguration : BaseEntityConfiguration<Grade> 
{
    public override void Configure(EntityTypeBuilder<Grade> builder)
    {
        builder.ToTable("Grades");

        builder.HasKey(sc => new { sc.StudentCourseId, sc.Type });

        builder.Property(s => s.StudentCourseId).IsRequired();

        builder.Property(s => s.Type).IsRequired();

        builder.Property(s => s.Value).IsRequired();

        base.Configure(builder);
    }
}
