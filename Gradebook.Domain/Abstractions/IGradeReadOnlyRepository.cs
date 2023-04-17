using Gradebook.Domain.Entities;

namespace Gradebook.Domain.Abstractions;

public interface IGradeReadOnlyRepository
{
    Task<IEnumerable<Grade>> GetByStudentCourseIdAsync(int studentCourseId, CancellationToken cancellationToken = default);
}
