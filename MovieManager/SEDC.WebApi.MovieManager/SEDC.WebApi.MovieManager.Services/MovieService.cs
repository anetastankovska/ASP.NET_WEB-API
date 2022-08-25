using AutoMapper;
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
        private readonly IMapper _mapper;

        public MovieService(IRepository<Movie> movierepository, IMapper mapper)
        {
            _movierepository = movierepository;
            _mapper = mapper;
        }

        public IEnumerable<MovieDto> GetAll()
        {
            return _movierepository.GetAll().Select(_mapper.Map<Movie, MovieDto>);
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

        public void Insert(CreateMovieDto entity)
        {
            var isValidEnum = Enum.TryParse(entity.Genre, out Genre parsedGenre);
            var movie = new Movie
            {
                Id = _movierepository.GetAll().Count() + 1,
                Title = entity.Title,
                Description = entity.Description,
                Year = entity.Year,
                Genre = parsedGenre
            };
            _movierepository.Insert(movie);
        }

        public void Update(MovieDto entity)
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
            var moviedtos = _movierepository.GetAll().Select(_mapper.Map<Movie, MovieDto>);
            return moviedtos.Where(filter);
        }

        public void Update(UpdateMovieDto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieDto> GetByGenre(string genre)
        {
            var isparsedGenre = Enum.TryParse(nameof(Genre), out Genre parsedGenre);
            //var movies = _movierepository.FilterBy(x => x.Genre.ToString() == genre).Select(movie => movie.Map());
            var movies = _movierepository.FilterBy(x => x.Genre == parsedGenre).Select(_mapper.Map<Movie, MovieDto>);
            if (!movies.Any())
            {
                throw new Exception($"No movies found for the genre {genre} or the genre {genre} does not exist.");
            }
            return movies;
        }
    }
}
