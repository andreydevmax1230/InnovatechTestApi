namespace Innovatech.Domain.UnitOfWork;

/// <summary>
/// Interfaces represent design pattern UnitOfWork
/// </summary>
public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken cancellationToken);
}
