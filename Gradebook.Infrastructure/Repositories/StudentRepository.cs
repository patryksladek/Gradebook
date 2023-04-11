using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;

namespace Gradebook.Infrastructure.Repositories;

internal class StudentRepository : IStudentRepository
{
    public Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Student> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Student> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsAlreadyExistAsync(string email, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Add(Student student)
    {
        throw new NotImplementedException();
    }

    public void Update(Student student)
    {
        throw new NotImplementedException();
    }

    public void Delete(Student student)
    {
        throw new NotImplementedException();
    }
}
