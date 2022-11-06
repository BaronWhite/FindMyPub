using FindMyPubApi.BusinessLogic.Models;
using FindMyPubApi.BusinessLogic.Repositories;

namespace FindMyPubApi.BusinessLogic.Services;

public class PubService : EntityService<Pub>, IPubService
{
    public PubService(IEntityRepository<Pub> repository) : base(repository)
    {
    }

    public async Task<IReadOnlyList<Pub>> GetWithName(string searchString)
    {
        var pubs = await _repository.Get();
        if (string.IsNullOrEmpty(searchString)) return pubs;
        var filteredPubs = pubs.Where(pub => (pub.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))).ToList();
        return filteredPubs;
    }
}
