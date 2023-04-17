using Gradebook.Domain.Entities;

namespace Gradebook.Domain.Abstractions;

public interface IGradeRepository
{
    Task<bool> IsAlreadyExistAsync(int studentCourseId, GradeType type, CancellationToken cancellationToken = default);

    void Add(Grade grade);
}
