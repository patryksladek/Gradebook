using Gradebook.Domain.Entities;

namespace Gradebook.Domain.Abstractions;

public interface ICourseRepository
{
    Task<bool> IsAlreadyExistAsync(string name, CancellationToken cancellationToken = default);
    void Add(Course course);
}
