namespace FindMyPubApi.BusinessLogic.Models;

public class PubReview : Entity
{
    public Pub Pub { get; set; }
    public long PubId { get; set; }
    public DateTime Date { get; set; }
    public string Excerpt { get; set; }
    public float StarsBeer { get; set; }
    public float StarsAtmosphere { get; set; }
    public float StarsAmenities { get; set; }
    public float StarsValue { get; set; }
};
