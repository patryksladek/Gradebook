﻿using Gradebook.Domain.Entities;
using Gradebook.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace Gradebook.Infrastructure.Context;

internal class GradebookDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Grade> Grades { get; set; }

    public GradebookDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("gradebook");

        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());
        modelBuilder.ApplyConfiguration(new GradeConfiguration());
    }
}
