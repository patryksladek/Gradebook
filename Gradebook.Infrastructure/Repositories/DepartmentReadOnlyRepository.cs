using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;
using Gradebook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Gradebook.Infrastructure.Repositories;

internal class DepartmentReadOnlyRepository : IDepartmentReadOnlyRepository
{
    private readonly GradebookDbContext _dbContext;

    public DepartmentReadOnlyRepository(GradebookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Department>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _dbContext.Departments.AsNoTracking().ToListAsync(cancellationToken);
}
