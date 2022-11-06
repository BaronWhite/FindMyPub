namespace FindMyPubApi.BusinessLogic.Models;

public record PubReview : Entity
{
    public Pub Pub { get; init; }
    public long PubId { get; init; }
    public DateTime Date { get; set; }
    public string Excerpt { get; set; }
    public float StarsBeer { get; set; }
    public float StarsAtmosphere { get; set; }
    public float StarsAmenities { get; set; }
    public float StarsValue { get; set; }
};
