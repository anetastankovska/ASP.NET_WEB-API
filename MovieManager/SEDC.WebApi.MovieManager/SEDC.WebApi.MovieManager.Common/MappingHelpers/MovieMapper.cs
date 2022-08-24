using SEDC.WebApi.MovieManager.DataModels.Enums;
using SEDC.WebApi.MovieManager.DataModels.Models;
using SEDC.WebApi.MovieManager.ServiceModels.MovieModels;

namespace SEDC.WebApi.MovieManager.Common.MappingHelpers
{
    public static class MovieMapper
    {
        public static MovieDto Map(this Movie movie)
        {
            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                Genre = movie.Genre.ToString(),
            };
        }

        public static Movie Map(this MovieDto movieDto)
        {
            var isValidGenre = Enum.TryParse(movieDto.Genre, out Genre parsedGenre);
            return new Movie
            {
                Id = movieDto.Id,
                Title = movieDto.Title,
                Description = movieDto.Description,
                Year = movieDto.Year,
                Genre = parsedGenre
            };
        }
    }
}
