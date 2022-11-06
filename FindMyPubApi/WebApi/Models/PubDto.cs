using FindMyPubApi.BusinessLogic.Models;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Runtime.InteropServices.ComTypes;

namespace FindMyPubApi.WebApi.Models;

/// <summary>
/// An establishment for the sale of beer and other drinks, and sometimes also food, to be consumed on the premises.
/// </summary>
/// <param name="Name">Name of the establishment</param>
/// <param name="Category">Category of the pub</param>
/// <param name="Thumbnail">Url to a thumbnail</param>
/// <param name="Location">Location details</param>
/// <param name="Url">Url to the website</param>
/// <param name="Phone">Contact number</param>
/// <param name="Twitter">Twitter handle</param>
/// <param name="Tags">Associated tags</param>
/// <param name="Reviews">List of reviews</param>
/// <param name="StarsBeer">Overall rating of the beer</param>
/// <param name="StarsAtmosphere">Overall rating of the atmosphere</param>
/// <param name="StarsAmenities">Overall rating of the amenities</param>
/// <param name="StarsValue">Overall rating of the pub</param>
public record PubDto
(
    [Required] long Id,
    [Required] string Name,
    [Required] string Category,
    [Required] string Thumbnail,
    [Required] LocationDto Location,
    [Required] string Url,
    [Required] string Phone,
    string Twitter,
    List<string>? Tags,
    List<PubReviewDto>? Reviews,
    float StarsBeer,
    float StarsAtmosphere,
    float StarsAmenities,
    float StarsValue
)
{
    public static explicit operator PubDto(Pub pub) => FromPub(pub);
    public static explicit operator Pub(PubDto pubDto) => ToPub(pubDto);

    /// <summary>Associated tags</summary>
    public List<string> Tags { get; init; } = Tags ?? new List<string>();

    /// <summary>List of reviews</summary>
    public List<PubReviewDto>? Reviews { get; init; } = Reviews ?? new List<PubReviewDto>();

    private static PubDto FromPub(Pub pub) =>
        new PubDto(
            Id: pub.Id,
            Name: pub.Name,
            Category: pub.Category,
            Thumbnail: pub.Thumbnail,
            Location: new LocationDto(
                Address: pub.Address,
                Longitude: pub.Longitude,
                Latitude: pub.Latitude
            ),
            Url: pub.Url,
            Phone: pub.Phone,
            Twitter: pub.Twitter,
            Tags: pub.Tags,
            Reviews: pub.Reviews.Select(review => (PubReviewDto)review).ToList(),
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
            Reviews = pubDto.Reviews.Select(review => (PubReview)review).ToList(),
        };
}
