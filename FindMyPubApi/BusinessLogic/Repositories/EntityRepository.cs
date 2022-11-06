using FindMyPubApi.BusinessLogic.Contexts;
using FindMyPubApi.BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace FindMyPubApi.BusinessLogic.Repositories
{
    public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : Entity
    {
        protected readonly MyPubDbContext _context;

        public EntityRepository(MyPubDbContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IReadOnlyList<TEntity>> Get()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity?> GetById(long id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task Update(long id, TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
                {
                    throw new KeyNotFoundException();
                }
                else
                {
                    throw;
                }
            }
        }

        public virtual async Task Delete(long id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException();
            }
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        protected bool EntityExists(long id)
        {
            return _context.Set<TEntity>().Find(id) != null;
        }
        protected bool EntityExists<TTEntity>(long id) where TTEntity : class
        {
            return _context.Set<TTEntity>().Find(id) != null;
        }
    }
}
