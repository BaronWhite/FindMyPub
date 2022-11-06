using AutoMapper;
using FindMyPubApi.BusinessLogic.AutoMapper;
using FindMyPubApi.BusinessLogic.Models;
using FluentAssertions;

namespace BusinessLogic.Tests.AutoMapper
{
    public class AutoMapperProfileTests
    {
        [Fact]
        public void AssertConfigurationIsValid_True()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            config.AssertConfigurationIsValid();
        }

        [Fact]
        public void Map_ConvertPubCsvRow_ExpectedResult()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();
            var pubCsvRow = new PubCsvRow(
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
            );
            var expected = new Pub()
            {
                Location = new Location()
                {
                    Address = "23-25 Great George Street, Leeds LS1 3BB",
                    Latitude = 53.8007317,
                    Longitude = -1.5481764,
                },
                Reviews = new List<PubReview>()
                {
                    new PubReview()
                    {
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
            };

            var actual = mapper.Map<Pub>(pubCsvRow);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
