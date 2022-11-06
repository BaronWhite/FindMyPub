using FindMyPubApi.BusinessLogic.Models;

namespace FindMyPubApi.BusinessLogic.Services;

public interface IEntityService<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Creates an entity
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<TEntity> Create(TEntity entity);

    /// <summary>
    /// Deletes an entity
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task Delete(long id);

    /// <summary>
    /// Gets all the entities
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<TEntity>> Get();

    /// <summary>
    /// Gets an entity by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TEntity?> GetById(long id);

    /// <summary>
    /// Updates and entity
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task Update(long id, TEntity entity);
}
