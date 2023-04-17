using Gradebook.Domain.Abstractions;
using Gradebook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Gradebook.Domain.Entities;
using System.Linq;

namespace Gradebook.Infrastructure.Repositories;

internal class GradeRepository : IGradeRepository
{
    private readonly GradebookDbContext _dbContext;

    public GradeRepository(GradebookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> IsAlreadyExistAsync(int studentCourseId, GradeType type, CancellationToken cancellationToken = default)
        => await _dbContext.Grades.AnyAsync(x => x.StudentCourseId == studentCourseId && x.Type == type, cancellationToken);

    public void Add(Grade grade) 
        => _dbContext.Grades.Add(grade);

    
}
