using System.ComponentModel.DataAnnotations;

namespace FindMyPubApi.BusinessLogic.Models;

public record Entity
{
    [Key]
    public long Id { get; init; }
}
