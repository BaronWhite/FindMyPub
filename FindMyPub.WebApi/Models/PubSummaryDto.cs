using FindMyPubApi.BusinessLogic.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindMyPubApi.WebApi.Models;

public record PubSummaryDto(
    [Required] long Id,
    [Required] string Name,
    [Required] string Category,
    [Required] string Thumbnail,
    [Required] LocationDto Location,
    [Required] [Url] string Url,
    [Required] string Phone,
    string Twitter,
    List<string>? Tags,
    float StarsBeer,
    float StarsAtmosphere,
    float StarsAmenities,
    float StarsValue
)
{
    /// <summary>Unique identifier</summary>
    public long Id { get; init; } = Id;

    /// <summary>Name of the establishment</summary>
    /// <example>Queens Head</example>
    public string Name { get; init; } = Name;

    /// <summary>Category of the pub</summary>
    public string Category { get; init; } = Category;

    /// <summary>Url to a thumbnail</summary>
    public string Thumbnail { get; init; } = Thumbnail;

    /// <summary>Location details</summary>
    public LocationDto Location { get; init; } = Location;

    /// <summary>Url to the website</summary>

    public string Url { get; init; } = Url;

    /// <summary>Contact number</summary>
    public string Phone { get; init; } = Phone;

    /// <summary>Twitter handle</summary>
    public string Twitter { get; init; } = Twitter;

    /// <summary>Associated tags</summary>
    public List<string> Tags { get; init; } = Tags ?? new List<string>();

    /// <summary>Overall rating of the beer</summary>
    /// <example>2</example>
    public float StarsBeer { get; init; } = StarsBeer;

    /// <summary>Overall rating of the atmosphere</summary>
    public float StarsAtmosphere { get; init; } = StarsAtmosphere;

    /// <summary>Overall rating of the amenities</summary>
    /// <example>3</example>
    public float StarsAmenities { get; init; } = StarsAmenities;

    /// <summary>Overall rating of the pub</summary>
    /// <example>2</example>
    public float StarsValue { get; init; } = StarsValue;

    public static explicit operator PubSummaryDto(Pub pub) => PubDto.FromPub(pub);

    private static PubSummaryDto FromPub(Pub pub) =>
        new PubSummaryDto(
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
            StarsBeer: pub.StarsBeer,
            StarsAtmosphere: pub.StarsAtmosphere,
            StarsAmenities: pub.StarsAmenities,
            StarsValue: pub.StarsValue
        );
}
