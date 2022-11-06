namespace FindMyPubApi.BusinessLogic.Models
{
    public record PubCsvRow
    (
        string name,
        string category,
        string url,
        string date,
        string excerpt,
        string thumbnail,
        string lat,
        string lng,
        string address,
        string phone,
        string twitter,
        string stars_beer,
        string stars_atmosphere,
        string stars_amenities,
        string stars_value,
        string tags
    );
}
