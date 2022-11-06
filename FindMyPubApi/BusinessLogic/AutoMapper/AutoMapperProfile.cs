using AutoMapper;
using FindMyPubApi.BusinessLogic.Models;

namespace FindMyPubApi.BusinessLogic.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<PubCsvRow, PubReview>()
            .ForMember(review => review.StarsBeer, expression => expression.MapFrom(row => row.stars_beer))
            .ForMember(review => review.StarsAtmosphere, expression => expression.MapFrom(row => row.stars_atmosphere))
            .ForMember(review => review.StarsAmenities, expression => expression.MapFrom(row => row.stars_amenities))
            .ForMember(review => review.StarsValue, expression => expression.MapFrom(row => row.stars_value));
        CreateMap<PubCsvRow, Location>()
            .ForMember(location => location.Latitude, expression => expression.MapFrom(row => row.lat))
            .ForMember(location => location.Longitude, expression => expression.MapFrom(row => row.lng));
        CreateMap<PubCsvRow, Pub>()
            .ForMember(pub => pub.Location, expression => expression.MapFrom(row => row))
            .ForMember(pub => pub.Reviews, expression => expression.ConvertUsing(new PubReviewConverter(), row => row))
            .ForMember(pub => pub.Tags, expression => expression.MapFrom(row => row.tags.Split(',', StringSplitOptions.TrimEntries).ToList()));
    }

    public class PubReviewConverter : IValueConverter<PubCsvRow, List<PubReview>>
    {
        public List<PubReview> Convert(PubCsvRow sourceMember, ResolutionContext context)
        {
            var review = context.Mapper.Map<PubReview>(sourceMember);
            var reviews = new List<PubReview>() { review };
            return reviews;
        }
    }
}
