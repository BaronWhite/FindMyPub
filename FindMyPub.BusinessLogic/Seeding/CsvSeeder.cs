using FindMyPubApi.BusinessLogic.Models;
using FindMyPubApi.BusinessLogic.Services;

namespace FindMyPubApi.BusinessLogic.Seeding;

public class CsvSeeder : ISeeder
{
    private const string CsvName = "leedsbeerquest.csv";
    private readonly ICsvService _csvService;

    public CsvSeeder(ICsvService csvService)
    {
        _csvService = csvService;
    }

    public IReadOnlyList<Pub> GetRecords()
    {
        var csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CsvName);
        var records = _csvService.ReadRecordsFromCsv(csvPath);
        var pubs = records.Select((row, i) => CsvRowToPub(row, i + 1)).ToList();

        return pubs;
    }

    private static Pub CsvRowToPub(PubCsvRow row, long id)
    {
        return new Pub()
        {
            Id = id,
            Address = row.address,
            Latitude = Convert.ToDouble(row.lat),
            Longitude = Convert.ToDouble(row.lng),
            Reviews = new List<PubReview>()
            {
                new PubReview()
                {
                    Id = id,
                    PubId = id,
                    Date = DateTime.Parse(row.date),
                    Excerpt = row.excerpt,
                    StarsAmenities = Convert.ToSingle(row.stars_amenities),
                    StarsAtmosphere = Convert.ToSingle(row.stars_atmosphere),
                    StarsBeer = Convert.ToSingle(row.stars_beer),
                    StarsValue = Convert.ToSingle(row.stars_value),
                },
            },
            Category = row.category,
            Name = row.name,
            Phone = row.phone,
            Tags = row.tags.Split(',', StringSplitOptions.TrimEntries).ToList(),
            Thumbnail = row.thumbnail,
            Twitter = row.twitter,
            Url = row.url,
        };
    }
}
