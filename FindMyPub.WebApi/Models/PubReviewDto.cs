using FindMyPubApi.BusinessLogic.Models;
using System.ComponentModel.DataAnnotations;

namespace FindMyPubApi.WebApi.Models;

/// <summary>
/// A customer review of a pub
/// </summary>
public record PubReviewDto(
    [Required] long Id,
    [Required] long PubId,
    [Required] DateTime Date,
    [Required] string Excerpt,
    [Required] [Range(1, 5)] float StarsBeer,
    [Required] [Range(1, 5)] float StarsAtmosphere,
    [Required] [Range(1, 5)] float StarsAmenities,
    [Required] [Range(1, 5)] float StarsValue
)
{
    public static explicit operator PubReviewDto(PubReview review) => FromPubReview(review);
    public static explicit operator PubReview(PubReviewDto review) => ToPubReview(review);

    /// <summary>Id of the Pub the review relates to</summary>
    public long PubId { get; init; } = PubId;

    /// <summary>Date the review was written</summary>
    public DateTime Date { get; init; } = Date;

    /// <summary>The review itself</summary>
    public string Excerpt { get; init; } = Excerpt;

    /// <summary>Rating of the beer</summary>
    /// <example>3</example>
    public float StarsBeer { get; init; } = StarsBeer;

    /// <summary>Rating of the atmosphere</summary>
    /// <example>3</example>
    public float StarsAtmosphere { get; init; } = StarsAtmosphere;

    /// <summary>Rating of the amenities</summary>
    /// <example>3</example>
    public float StarsAmenities { get; init; } = StarsAmenities;

    /// <summary>Rating of the pub</summary>
    /// <example>3</example>
    public float StarsValue { get; init; } = StarsValue;

    private static PubReviewDto FromPubReview(PubReview review) =>
        new PubReviewDto(
            Id: review.Id,
            PubId: review.PubId,
            Date: review.Date,
            Excerpt: review.Excerpt,
            StarsBeer: review.StarsBeer,
            StarsAtmosphere: review.StarsAtmosphere,
            StarsAmenities: review.StarsAmenities,
            StarsValue: review.StarsValue
        );

    private static PubReview ToPubReview(PubReviewDto reviewDto) =>
        new PubReview()
        {
            Id = reviewDto.Id,
            PubId = reviewDto.PubId,
            Date = reviewDto.Date,
            Excerpt = reviewDto.Excerpt,
            StarsBeer = reviewDto.StarsBeer,
            StarsAtmosphere = reviewDto.StarsAtmosphere,
            StarsAmenities = reviewDto.StarsAmenities,
            StarsValue = reviewDto.StarsValue
        };
}
