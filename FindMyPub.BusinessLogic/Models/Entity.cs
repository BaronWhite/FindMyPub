using System.ComponentModel.DataAnnotations;

namespace FindMyPubApi.BusinessLogic.Models;

public class Entity
{
    [Key]
    public long Id { get; init; }
}
