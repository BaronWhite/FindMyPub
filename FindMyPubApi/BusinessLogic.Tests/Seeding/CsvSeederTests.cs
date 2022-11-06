using FindMyPubApi.BusinessLogic.Models;
using FindMyPubApi.BusinessLogic.Seeding;
using FindMyPubApi.BusinessLogic.Services;
using FluentAssertions;
using Moq;

namespace FindMyPubApi.BusinessLogic.Tests.Seeding;

public class CsvSeederTests : AutoFixtureTestBase
{
    private readonly CsvSeeder _sut;
    private readonly Mock<ICsvService> _csvService;

    public CsvSeederTests()
    {
        _csvService = FreezeMock<ICsvService>();
        _csvService.Setup(service => service.ReadRecordsFromCsv(It.IsAny<string>())).Returns(MockPubCsvRows);
        _sut = Create<CsvSeeder>();
    }

    [Fact]
    public void GetRecords_CallsCsvService()
    {
        _sut.GetRecords();

        _csvService.Verify(service => service.ReadRecordsFromCsv(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public void GetRecords_ReturnsConvertedRows()
    {
        var expected = MockPubs;

        var actual = _sut.GetRecords();

        actual.Should().BeEquivalentTo(expected);
    }

    private static readonly List<PubCsvRow> MockPubCsvRows = new List<PubCsvRow>()
    {
        new PubCsvRow(
            address: "23-25 Great George Street, Leeds LS1 3BB",
            category: "Closed venues",
            date: "2012-11-30T21:58:52+00:00",
            excerpt: "...It's really dark in here!",
            lat: "53.8007317",
            lng: "-1.5481764",
            name: "...escobar",
            phone: "0113 220 4389",
            stars_amenities: "3",
            stars_atmosphere: "3",
            stars_beer: "2",
            stars_value: "3",
            tags: "food,live music,sofas",
            thumbnail: "http://leedsbeer.info/wp-content/uploads/2012/11/20121129_185815.jpg",
            twitter: "EscobarLeeds",
            url: "http://leedsbeer.info/?p=765"
        )
    };

    private readonly List<Pub> MockPubs = new()
    {
        new Pub()
        {
            Id = 1,
            Location = new Location()
            {
                Id = 1,
                PubId = 1,
                Address = "23-25 Great George Street, Leeds LS1 3BB",
                Latitude = 53.8007317,
                Longitude = -1.5481764,
            },
            Reviews = new List<PubReview>()
            {
                new PubReview()
                {
                    Id = 1,
                    PubId = 1,
                    Date = DateTime.Parse("2012-11-30T21:58:52"),
                    Excerpt = "...It's really dark in here!",
                    StarsAmenities = 3,
                    StarsAtmosphere = 3,
                    StarsBeer = 2,
                    StarsValue = 3,
                },
            },
            Category = "Closed venues",
            Name = "...escobar",
            Phone = "0113 220 4389",
            Tags = new List<string>() { "food", "live music", "sofas" },
            Thumbnail = "http://leedsbeer.info/wp-content/uploads/2012/11/20121129_185815.jpg",
            Twitter = "EscobarLeeds",
            Url = "http://leedsbeer.info/?p=765",
        }
    };
}
