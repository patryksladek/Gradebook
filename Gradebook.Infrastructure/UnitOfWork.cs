using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;

namespace Gradebook.Infrastructure;

internal class UnitOfWork : IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
