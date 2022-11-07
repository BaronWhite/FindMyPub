using System.ComponentModel.DataAnnotations;

namespace FindMyPubApi.WebApi.Models;

/// <summary>
/// Location details of a pub
/// </summary>
public record LocationDto(string Address, double Latitude, double Longitude)
{
    /// <summary>Full address</summary>
    public string Address { get; init; } = Address;

    /// <summary>Latitude, between -90 and 90</summary>
    [Range(-90, 90)]
    public double Latitude { get; init; } = Latitude;

    /// <summary>Longitude, between -180 and 180</summary>
    [Range(-180, 180)]
    public double Longitude { get; init; } = Longitude;
}
