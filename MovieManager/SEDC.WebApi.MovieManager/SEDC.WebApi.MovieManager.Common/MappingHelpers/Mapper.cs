using SEDC.WebApi.MovieManager.DataModels.Enums;
using SEDC.WebApi.MovieManager.DataModels.Models;
using SEDC.WebApi.MovieManager.ServiceModels.MovieModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.MovieManager.Common.MappingHelpers
{
    public static class Mapper
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

        //public static MovieDto Map(this MovieDto movieDto)
        //{
        //    return new Movie
        //    {
        //        Id = movieDto.Id,
        //        Title = movieDto.Title,
        //        Description = movieDto.Description,
        //        Year = movieDto.Year,
        //        Genre = movieDto.(Genre)Genre,
        //    };
        //}
    }
}
