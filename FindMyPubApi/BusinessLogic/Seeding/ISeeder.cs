using FindMyPubApi.BusinessLogic.Models;

namespace FindMyPubApi.BusinessLogic.Seeding;

public interface ISeeder
{
    IReadOnlyList<Pub> GetRecords();
}
