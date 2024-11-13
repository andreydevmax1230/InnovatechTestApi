using Innovatech.Domain.UnitOfWork;

namespace Innovatech.Infraestructure;

/// <summary>
///  Class represent design pattern UnitOfWork
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly Entities _dbContext;

    public UnitOfWork(Entities entities)
    {
        _dbContext = entities;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}