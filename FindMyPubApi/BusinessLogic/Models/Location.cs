using System.Text.Json.Serialization;

namespace FindMyPubApi.BusinessLogic.Models;

public record Location : Entity
{
    [JsonIgnore]
    public Pub Pub { get; init; }
    public long PubId { get; init; }
    public string Address { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
};
