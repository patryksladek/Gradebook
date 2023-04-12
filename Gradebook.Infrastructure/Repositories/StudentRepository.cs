using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;
using Gradebook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Gradebook.Infrastructure.Repositories;

internal class StudentRepository : IStudentRepository
{
    private readonly GradebookDbContext _dbContext;

    public StudentRepository(GradebookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Student> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _dbContext.Students.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<Student> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        => await _dbContext.Students.SingleOrDefaultAsync(x => x.Email == email, cancellationToken);

    public async Task<bool> IsAlreadyExistAsync(string email, CancellationToken cancellationToken = default)
        => await _dbContext.Students.AnyAsync(x => x.Email == email, cancellationToken);

    public void Add(Student student)
       => _dbContext.Students.Add(student);

    public void Update(Student student)
        => _dbContext.Students.Update(student);

    public void Delete(Student student)
        => _dbContext.Students.Remove(student);
}
