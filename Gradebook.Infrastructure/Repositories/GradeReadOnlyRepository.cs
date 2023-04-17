using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;
using Gradebook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Gradebook.Infrastructure.Repositories;

internal class GradeReadOnlyRepository : IGradeReadOnlyRepository
{
    private readonly GradebookDbContext _dbContext;

    public GradeReadOnlyRepository(GradebookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Grade>> GetByStudentCourseIdAsync(int studentCourseId, CancellationToken cancellationToken = default)
        => await _dbContext.Grades.Where(x => x.StudentCourseId == studentCourseId).ToListAsync(cancellationToken);

}
