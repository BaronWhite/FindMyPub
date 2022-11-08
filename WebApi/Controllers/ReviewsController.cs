using FindMyPubApi.BusinessLogic.Models;
using FindMyPubApi.BusinessLogic.Services;
using FindMyPubApi.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FindMyPubApi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IEntityService<PubReview> _service;

    public ReviewsController(IEntityService<PubReview> service)
    {
        _service = service;
    }

    /// <summary>
    /// Gets a review by id
    /// </summary>
    /// <returns></returns>
    [HttpGet("{reviewId}")]
    public async Task<ActionResult<PubReviewDto>> GetPubReview(long reviewId)
    {
        var review = await _service.GetById(reviewId);
        if (review is null) return NotFound();
        return (PubReviewDto)review;
    }

    /// <summary>
    /// Creates a new review for a Pub
    /// </summary>
    /// <param name="review"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<PubReviewDto>> CreatePubReview(PubReviewDto review)
    {
        var created = await _service.Create((PubReview)review);
        return CreatedAtAction(nameof(CreatePubReview), new { id = created.Id }, (PubReviewDto)created);
    }
}
