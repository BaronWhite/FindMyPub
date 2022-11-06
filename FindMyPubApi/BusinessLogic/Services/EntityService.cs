using FindMyPubApi.BusinessLogic.Models;
using FindMyPubApi.BusinessLogic.Repositories;

namespace FindMyPubApi.BusinessLogic.Services
{
    public class EntityService<TEntity> : IEntityService<TEntity>
        where TEntity : Entity
    {
        protected readonly IEntityRepository<TEntity> _repository;

        public EntityService(IEntityRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            return await _repository.Create(entity);
        }

        public async Task Delete(long id)
        {
            await _repository.Delete(id);
        }

        public async Task<IReadOnlyList<TEntity>> Get()
        {
            return await _repository.Get();
        }

        public async Task<TEntity?> GetById(long id)
        {
            return await _repository.GetById(id);
        }

        public Task Update(long id, TEntity entity)
        {
            return _repository.Update(id, entity);
        }
    }
}
