using Gradebook.Domain.Entities;

namespace Gradebook.Domain.Abstractions;

public interface IDepartmentRepository
{
    Task<Department> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<bool> IsAlreadyExistAsync(string name, CancellationToken cancellationToken = default);
    void Add(Department department);
}
