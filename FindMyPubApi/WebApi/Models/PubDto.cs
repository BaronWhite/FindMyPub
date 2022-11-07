using FindMyPubApi.BusinessLogic.Models;

namespace FindMyPubApi.WebApi.Models;

public record PubDto(
    long Id,
    string Name,
    string Category,
    string Thumbnail,
    LocationDto Location,
    string Url,
    string Phone,
    string Twitter,
    List<string>? Tags,
    List<PubReviewDto>? Reviews,
    float StarsBeer,
    float StarsAtmosphere,
    float StarsAmenities,
    float StarsValue
) : PubSummaryDto(
    Id: Id,
    Name: Name,
    Category: Category,
    Thumbnail: Thumbnail,
    Location: Location,
    Url: Url,
    Phone: Phone,
    Twitter: Twitter,
    Tags: Tags,
    StarsBeer: StarsBeer,
    StarsAtmosphere: StarsAtmosphere,
    StarsAmenities: StarsAmenities,
    StarsValue: StarsValue
)
{
    /// <summary>List of reviews</summary>
    public List<PubReviewDto>? Reviews { get; init; } = Reviews ?? new List<PubReviewDto>();

    public static explicit operator PubDto(Pub pub) => PubDto.FromPub(pub);
    public static explicit operator Pub(PubDto pubDto) => PubDto.ToPub(pubDto);

    private static PubDto FromPub(Pub pub) =>
        new PubDto(
            Id: pub.Id,
            Name: pub.Name,
            Category: pub.Category,
            Thumbnail: pub.Thumbnail,
            new LocationDto(
                Address: pub.Address,
                Latitude: pub.Longitude,
                Longitude: pub.Latitude
            ),
            Url: pub.Url,
            Phone: pub.Phone,
            Twitter: pub.Twitter,
            Tags: pub.Tags,
            Reviews: pub.Reviews.Select(selector: review => (PubReviewDto)review).ToList(),
            StarsBeer: pub.StarsBeer,
            StarsAtmosphere: pub.StarsAtmosphere,
            StarsAmenities: pub.StarsAmenities,
            StarsValue: pub.StarsValue
        );

    private static Pub ToPub(PubDto pubDto) =>
        new Pub()
        {
            Id = pubDto.Id,
            Name = pubDto.Name,
            Category = pubDto.Category,
            Thumbnail = pubDto.Thumbnail,
            Address = pubDto.Location.Address,
            Longitude = pubDto.Location.Longitude,
            Latitude = pubDto.Location.Latitude,
            Url = pubDto.Url,
            Phone = pubDto.Phone,
            Twitter = pubDto.Twitter,
            Tags = pubDto.Tags,
            Reviews = pubDto.Reviews?.Select(selector: review => (PubReview)review).ToList() ?? new List<PubReview>(),
        };
}
