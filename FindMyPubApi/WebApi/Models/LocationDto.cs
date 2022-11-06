using System.ComponentModel.DataAnnotations;

namespace FindMyPubApi.WebApi.Models;

/// <summary>
/// Location details of a pub
/// </summary>
/// <param name="PubId"></param>
/// <param name="Address"></param>
/// <param name="Latitude"></param>
/// <param name="Longitude"></param>
public record LocationDto
(
    string Address,
    double Latitude,
    double Longitude
);
