using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;
using Gradebook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Gradebook.Infrastructure.Repositories;

internal class StudentReadOnlyRepository : IStudentReadOnlyRepository
{
    private readonly GradebookDbContext _dbContext;

    public StudentReadOnlyRepository(GradebookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _dbContext.Students.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<IEnumerable<Student>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default)
       => await _dbContext.Students
       .Include(x => x.Address)
       .AsNoTracking()
       .ToListAsync(cancellationToken);
}
