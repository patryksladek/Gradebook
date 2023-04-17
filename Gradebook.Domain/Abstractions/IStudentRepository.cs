using Gradebook.Domain.Entities;

namespace Gradebook.Domain.Abstractions;

public interface IStudentRepository
{
    Task<Student> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Student> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<Student> GetByIdWithCoursesAsync(int studentId, CancellationToken cancellationToken = default);
    Task<bool> IsAlreadyExistAsync(string email, CancellationToken cancellationToken = default);
    void Add(Student student);
    void Update(Student student);
    void Delete(Student student);
}
