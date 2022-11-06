using FindMyPubApi.BusinessLogic.Models;

namespace FindMyPubApi.BusinessLogic.Services;

public interface ICsvService
{
    IReadOnlyList<PubCsvRow> ReadRecordsFromCsv(string csvPath);
}
