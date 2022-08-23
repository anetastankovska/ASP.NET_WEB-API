using SEDC.WebApi.MovieManager.Common.MappingHelpers;
using SEDC.WebApi.MovieManager.DataAccess;
using SEDC.WebApi.MovieManager.DataModels.Enums;
using SEDC.WebApi.MovieManager.DataModels.Models;
using SEDC.WebApi.MovieManager.ServiceModels.MovieModels;
using SEDC.WebApi.MovieManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.MovieManager.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movierepository;

        public MovieService(IRepository<Movie> movierepository)
        {
            _movierepository = movierepository;
        }

        public IEnumerable<MovieDto> GetAll()
        {
            return _movierepository.GetAll().Select(x => x.Map()).ToList();
        }

        public MovieDto GetById(int id)
        {
            var movie = _movierepository.FilterBy(x => x.Id == id).FirstOrDefault();
            if(movie == null)
            {
                throw new Exception("Movie not found");
            }
            return movie.Map();
        }

        public int Insert(CreateMovieDto entity)
        {
            var movie = new Movie
            {
                Id = _movierepository.GetAll().Count() + 1,
                Title = entity.Title,
                Description = entity.Description,
                Year = entity.Year,
                Genre = entity.Genre as Genre
            };
        }

        public int Update(MovieDto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var movieTodelete = _movierepository.GetAll().FirstOrDefault(x => x.Id == id);
            if (movieTodelete != null)
            {
                _movierepository.Delete(movieTodelete);
            }
            else
            {
                throw new Exception("The movie cannot be found");         
            }
        }

        public IEnumerable<MovieDto> FilterBy(Func<MovieDto, bool> filter)
        {
            var moviedtos = _movierepository.GetAll().Select(x => x.Map());
            return moviedtos.Where(filter);
        }

        //public IEnumerable<MovieDto> GetByGenre(string genre)
        //{
        //    var isparsedGenre = Enum.TryParse(nameof(Genre), out Genre parsedGenre);
        //    //var movies = _movierepository.GetAll().Where(x => x.Genre == genre);
        //    //return movies.Select(x => x.Map());

        //    return _movierepository.FilterBy(x => x.Genre == parsedGenre).Select(movie => movie.Map());
        //}
    }
}
