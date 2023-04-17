using Gradebook.Domain.Entities;

namespace Gradebook.Domain.Abstractions;

public interface IDepartmentReadOnlyRepository
{
    Task<IEnumerable<Department>> GetAllAsync(CancellationToken cancellationToken = default);
}
