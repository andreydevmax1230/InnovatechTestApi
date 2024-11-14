using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Innovatech.Infraestructure.Configuration;

namespace Innovatech.Infraestructure;

/// <summary>
/// Config entities context DB
/// </summary>
public partial class Entities : IdentityDbContext
{
    #region Ctor
    private readonly IHttpContextAccessor _contextAccessor;
    public Entities()
    {
    }

    public Entities(DbContextOptions<Entities> options, IHttpContextAccessor contextAccessor = null) : base(options)
    {
        _contextAccessor = contextAccessor;
    }

    #endregion

    #region Utilities

    /// <summary>
    /// Further configuration the model
    /// </summary>
    /// <param name="builder">The builder being used to construct the model for this context</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TaskConfiguration());
        base.OnModelCreating(builder);
    }

    #endregion

    #region Methods

    /// <summary>
    /// Creates a DbSet that can be used to query and save instances of entity
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>A set for the given entity type</returns>
    public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : class
    {
        return base.Set<TEntity>();
    }

    #endregion
}