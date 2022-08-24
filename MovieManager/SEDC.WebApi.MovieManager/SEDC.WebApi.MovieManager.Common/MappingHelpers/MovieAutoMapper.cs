using AutoMapper;
using SEDC.WebApi.MovieManager.DataModels.Models;
using SEDC.WebApi.MovieManager.ServiceModels.MovieModels;

namespace SEDC.WebApi.MovieManager.Common.MappingHelpers
{
    public class MovieAutoMapper : Profile
    {
        public MovieAutoMapper()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(x => x.Genre.ToString())).ReverseMap();

            CreateMap<Movie, CreateMovieDto>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.ToString())).ReverseMap();

            CreateMap<Movie, UpdateMovieDto>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(x => x.Genre.ToString())).ReverseMap();
        }
    }
}
