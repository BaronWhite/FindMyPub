using FindMyPubApi.BusinessLogic.Contexts;
using FindMyPubApi.BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace FindMyPubApi.BusinessLogic.Repositories;

public class PubRepository : IEntityRepository<Pub>
{
    private readonly MyPubDbContext _context;

    public PubRepository(MyPubDbContext context)
    {
        _context = context;
    }

    public virtual async Task<Pub> Create(Pub entity)
    {
        await _context.Set<Pub>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<IReadOnlyList<Pub>> Get()
    {
        return await _context.Set<Pub>().Include(pub => pub.Reviews).ToListAsync();
    }

    public virtual async Task<Pub?> GetById(long id)
    {
        return await _context.Set<Pub>().Include(pub => pub.Reviews).FirstOrDefaultAsync(pub => pub.Id == id);
    }

    public virtual async Task Update(long id, Pub entity)
    {
        try
        {
            _context.Set<Pub>().Update(entity);
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
        var entity = await _context.Set<Pub>().FindAsync(id);
        if (entity == null)
        {
            throw new KeyNotFoundException();
        }

        _context.Set<Pub>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    protected bool EntityExists(long id)
    {
        return _context.Set<Pub>().Find(id) != null;
    }
}
