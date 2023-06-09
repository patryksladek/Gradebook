﻿using Gradebook.Domain.Entities;

namespace Gradebook.Domain.Abstractions;

public interface IStudentReadOnlyRepository
{
    Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Student>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default);
}
