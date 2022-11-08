using CsvHelper;
using CsvHelper.Configuration;
using FindMyPubApi.BusinessLogic.Models;
using System.Globalization;

namespace FindMyPubApi.BusinessLogic.Services;

public class CsvService : ICsvService
{
    public IReadOnlyList<PubCsvRow> ReadRecordsFromCsv(string csvPath)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => args.Header.ToLower(),
        };
        using var reader = new StreamReader(csvPath);
        using var csv = new CsvReader(reader, config);
        var records = csv.GetRecords<PubCsvRow>().ToList();
        return records;
    }
}
