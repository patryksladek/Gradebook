using Gradebook.Domain.Entities;

namespace Gradebook.Domain.Abstractions;

public interface ICourseReadOnlyRepository
{
    Task<IEnumerable<Course>> GetAllAsync(CancellationToken cancellationToken = default);
}
