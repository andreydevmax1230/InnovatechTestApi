using System.Linq.Expressions;

namespace Innovatech.Domain.Repositories;

/// <summary>
/// Represents an entity repository
/// </summary>
/// <typeparam name="TEntity">Entity type</typeparam>
public partial interface IRepository<TEntity> where TEntity : class
{
    #region Methods

    /// <summary>
    /// Get entity by identifier
    /// </summary>
    /// <param name="id">Identifier</param>
    /// <returns>Entity</returns>
    TEntity GetById(object id);

    /// <summary>
    /// Get entity not tracking record
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    TEntity GetEntityNotTracking(Expression<Func<TEntity, bool>> where);

    /// <summary>
    /// Get all entities
    /// </summary>
    /// <returns></returns>
    IEnumerable<TEntity> GetAll();

    /// <summary>
    /// GetMany entities
    /// </summary>
    /// <param name="where"></param>
    /// <returns></returns>
    IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);

    /// <summary>
    /// Get entity by where
    /// </summary>
    /// <param name="where"></param>
    /// <returns></returns>
    TEntity Get(Expression<Func<TEntity, bool>> where);

    /// <summary>
    /// Insert entity
    /// </summary>
    /// <param name="entity">Entity</param>
    void Insert(TEntity entity);

    /// <summary>
    /// Insert entities
    /// </summary>
    /// <param name="entities">Entities</param>
    void Insert(IEnumerable<TEntity> entities);

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">Entity</param>
    void Update(TEntity entity);

    /// <summary>
    /// Update entities
    /// </summary>
    /// <param name="entities">Entities</param>
    void Update(IEnumerable<TEntity> entities);

    /// <summary>
    /// Delete entity
    /// </summary>
    /// <param name="entity">Entity</param>
    void Delete(TEntity entity);

    /// <summary>
    /// Delete entities
    /// </summary>
    /// <param name="entities">Entities</param>
    void Delete(IEnumerable<TEntity> entities);

    /// <summary>
    /// Delete entities
    /// </summary>
    /// <param name="where"></param>
    void Delete(Expression<Func<TEntity, bool>> where);

    /// <summary>
    /// Get count of entities
    /// </summary>
    /// <param name="where"></param>
    /// <returns></returns>
    int Count(Expression<Func<TEntity, bool>> where);
    #endregion

    #region Properties

    /// <summary>
    /// Gets a table
    /// </summary>
    IQueryable<TEntity> Table { get; }

    /// <summary>
    /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
    /// </summary>
    IQueryable<TEntity> TableNoTracking { get; }

    #endregion
}