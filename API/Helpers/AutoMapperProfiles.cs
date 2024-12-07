using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Movie, MovieDto>();
        CreateMap<MovieMetadata, MovieMetadataDto>();
        CreateMap<OmdbDetailsResponse, MovieMetadata>()
            .ForMember(dest => dest.PosterUrl, opt => opt.MapFrom(src => src.Poster)) 
            .ForMember(dest => dest.ImdbId, opt => opt.MapFrom(src => src.ImdbID)) 
            .ForMember(dest => dest.Ratings, opt =>
                opt.MapFrom(src => src.Ratings!
                    .FirstOrDefault(r => r.Source == "Internet Movie Database")!.Value));
    }
}
