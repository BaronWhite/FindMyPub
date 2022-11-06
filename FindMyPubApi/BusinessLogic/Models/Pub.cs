namespace FindMyPubApi.BusinessLogic.Models;

public record Pub : Entity
{
    public string Name { get; set; }
    public string Category { get; set; }
    public string Thumbnail { get; set; }
    public Location Location { get; set; }
    public string Url { get; set; }
    public string Phone { get; set; }
    public string Twitter { get; set; }
    public List<string> Tags { get; set; }
    public List<PubReview> Reviews { get; set; }

    private float StarsBeer => Reviews.Select(review => review.StarsBeer).Average();
    private float StarsAtmosphere => Reviews.Select(review => review.StarsAtmosphere).Average();
    private float StarsAmenities => Reviews.Select(review => review.StarsAmenities).Average();
    private float StarsValue => Reviews.Select(review => review.StarsValue).Average();
}