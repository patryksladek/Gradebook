using Gradebook.Domain.Entities;
using Gradebook.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace Gradebook.Infrastructure.Context;

internal class GradebookDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }


    public GradebookDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("gradebook");

        modelBuilder.ApplyConfiguration(new StudentConfiguration());
    }
}
