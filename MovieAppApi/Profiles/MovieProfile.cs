using AutoMapper;
using MovieAppApi.Dtos;
using MovieAppApi.Model;

namespace MovieAppApi.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie,MovieReadDtos>();
            CreateMap<MovieCreateDtos, Movie>();
            CreateMap<URLDtos, Movie>();    
            CreateMap<MovieUpdateDto, Movie>();
            CreateMap<Movie, MovieUpdateDto>();
        }
    }
}
