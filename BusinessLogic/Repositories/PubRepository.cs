using FindMyPubApi.BusinessLogic.Contexts;
using FindMyPubApi.BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace FindMyPubApi.BusinessLogic.Repositories;

public class PubRepository : EntityRepository<Pub>
{
    public PubRepository(MyPubDbContext context) : base(context)
    {
    }

    public override async Task<IReadOnlyList<Pub>> Get()
    {
        return await _context.Set<Pub>().Include(pub => pub.Reviews).ToListAsync();
    }

    public override async Task<Pub?> GetById(long id)
    {
        return await _context.Set<Pub>().Include(pub => pub.Reviews).FirstOrDefaultAsync(pub => pub.Id == id);
    }
}

public class PubReviewRepository : EntityRepository<PubReview>
{
    public PubReviewRepository(MyPubDbContext context) : base(context)
    {
    }

    public override async Task<PubReview> Create(PubReview entity)
    {
        if (!EntityExists<Pub>(entity.PubId)) throw new ArgumentException($"There is no Pub with Id [{entity.PubId}]");

        await _context.Set<PubReview>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
