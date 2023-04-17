using Gradebook.Domain.Entities;
using Gradebook.Domain.Abstractions;
using Gradebook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Azure.Core;
using Gradebook.Domain.Exceptions.Department;
using System.Threading;

namespace Gradebook.Infrastructure.Repositories;

internal class DepartmentRepository : IDepartmentRepository
{
    private readonly GradebookDbContext _dbContext;

    public DepartmentRepository(GradebookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Department> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _dbContext.Departments.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<Department> GetByIdWithStudentsAsync(int id, CancellationToken cancellationToken = default)
        => await _dbContext.Departments
            .Include(x => x.Students)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    
    public async Task<bool> IsAlreadyExistAsync(string name, CancellationToken cancellationToken = default)
        => await _dbContext.Departments.SingleOrDefaultAsync(x => x.Name == name, cancellationToken) is not null;

    public void Add(Department department)
        => _dbContext.Departments.Add(department);

    public void Remove(Department department)
        => _dbContext.Departments.Remove(department);
}
