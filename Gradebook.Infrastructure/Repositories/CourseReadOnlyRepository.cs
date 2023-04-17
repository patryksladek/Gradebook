using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;
using Gradebook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Gradebook.Infrastructure.Repositories;

internal class CourseReadOnlyRepository : ICourseReadOnlyRepository
{
    private readonly GradebookDbContext _dbContext;

    public CourseReadOnlyRepository(GradebookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Course>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _dbContext.Courses.AsNoTracking().ToListAsync(cancellationToken);
}
