using Gradebook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gradebook.Infrastructure.Config;

public class StudentCourseConfiguration : BaseEntityConfiguration<StudentCourse>
{
    public override void Configure(EntityTypeBuilder<StudentCourse> builder)
    {
        builder.ToTable("StudentCourses");

        builder.HasKey(sc => new { sc.StudentId, sc.CourseId });

        base.Configure(builder);
    }
}
