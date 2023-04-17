using Gradebook.Domain.Entities;

namespace Gradebook.Domain.Abstractions;

public interface ICourseRepository
{
    Task<Course> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Course> GetByIdWithStudentsAsync(int id, CancellationToken cancellationToken = default);
    Task<bool> IsAlreadyExistAsync(string name, CancellationToken cancellationToken = default);
    void Add(Course course);
    void Update(Course course);
}
