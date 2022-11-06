using FindMyPubApi.BusinessLogic.Models;
using System.ComponentModel.DataAnnotations;

namespace FindMyPubApi.WebApi.Models;

/// <summary>
/// A customer review of a pub
/// </summary>
/// <param name="PubId">Id of the Pub the review relates to</param>
/// <param name="Date">Date the review was written</param>
/// <param name="Excerpt">The review itself</param>
/// <param name="StarsBeer">Rating of the beer</param>
/// <param name="StarsAtmosphere">Rating of the atmosphere</param>
/// <param name="StarsAmenities">Rating of the amenities</param>
/// <param name="StarsValue">Rating of the pub</param>
public record PubReviewDto
(
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
