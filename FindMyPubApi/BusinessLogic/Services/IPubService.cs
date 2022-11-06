using FindMyPubApi.BusinessLogic.Models;

namespace FindMyPubApi.BusinessLogic.Services;

public interface IPubService : IEntityService<Pub>
{
    /// <summary>
    /// Gets all pubs with the given string in their name
    /// </summary>
    /// <param name="searchString">Search string for pub name</param>
    /// <returns></returns>
    Task<IReadOnlyList<Pub>> GetWithName(string searchString);
}
