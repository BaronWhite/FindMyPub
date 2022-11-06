using FindMyPubApi.BusinessLogic.Models;

namespace FindMyPubApi.BusinessLogic.Repositories
{
    public interface IEntityRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> Create(TEntity entity);
        Task<IReadOnlyList<TEntity>> Get();
        Task<TEntity?> GetById(long id);
        Task Update(long id, TEntity entity);
        Task Delete(long id);
    }
}
