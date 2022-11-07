namespace FindMyPubApi.BusinessLogic.Models;

public class Pub : Entity
{
    public string Name { get; set; }
    public string Category { get; set; }
    public string Thumbnail { get; set; }
    public string Address { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public string Url { get; set; }
    public string Phone { get; set; }
    public string Twitter { get; set; }
    public List<string> Tags { get; set; }
    public List<PubReview> Reviews { get; set; }

    public float StarsBeer => Reviews.Select(review => review.StarsBeer).Average();
    public float StarsAtmosphere => Reviews.Select(review => review.StarsAtmosphere).Average();
    public float StarsAmenities => Reviews.Select(review => review.StarsAmenities).Average();
    public float StarsValue => Reviews.Select(review => review.StarsValue).Average();
}