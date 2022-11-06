using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using FindMyPubApi.BusinessLogic.Models;
using System.Globalization;

namespace FindMyPubApi.BusinessLogic.Seeding;

public class Seeder : ISeeder
{
    private const string CsvName = "leedsbeerquest.csv";
    private readonly IMapper _mapper;

    public Seeder(IMapper mapper)
    {
        _mapper = mapper;
    }

    private static IReadOnlyList<PubCsvRow> ReadRecordsFromCsv()
    {
        var csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CsvName);

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => args.Header.ToLower(),
        };
        using var reader = new StreamReader(csvPath);
        using var csv = new CsvReader(reader, config);
        var records = csv.GetRecords<PubCsvRow>().ToList();
        return records;
    }

    public IReadOnlyList<Pub> GetRecords()
    {
        var records = ReadRecordsFromCsv();

        var pubs = records.Select((row, i) =>
            {
                var id = i+1;
                return new Pub()
                {
                    Id = id,
                    Location = new Location()
                    {
                        Id = id,
                        PubId = id,
                        Address = row.address,
                        Latitude = Convert.ToDouble(row.lat),
                        Longitude = Convert.ToDouble(row.lng),
                    },
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
        ).ToList();

        //var pubs = records.Select(row => _mapper.Map<Pub>(row)).ToList();

        return pubs;
    }
}
