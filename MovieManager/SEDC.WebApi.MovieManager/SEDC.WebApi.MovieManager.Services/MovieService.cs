using AutoMapper;
using SEDC.WebApi.MovieManager.Common.MappingHelpers;
using SEDC.WebApi.MovieManager.DataAccess;
using SEDC.WebApi.MovieManager.DataModels.Enums;
using SEDC.WebApi.MovieManager.DataModels.Models;
using SEDC.WebApi.MovieManager.ServiceModels.MovieModels;
using SEDC.WebApi.MovieManager.Services.Interfaces;

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
            var movies = _movierepository.GetAll().Select(_mapper.Map<Movie, MovieDto>);
            if (movies.Any())
            {
                return movies;
            }
            else
            {
                throw new Exception("No movies found");
            }
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
            //var movie = new Movie
            //{
            //    Id = _movierepository.GetAll().Count() + 1,
            //    Title = entity.Title,
            //    Description = entity.Description,
            //    Year = entity.Year,
            //    Genre = parsedGenre
            //};
            //_movierepository.Insert(movie);

            var movie = _movierepository.Insert(_mapper.Map<Movie>(entity));
        }


        public void Delete(int id)
        {
            var movieToDelete = _movierepository.Delete(id);
        }

        public IEnumerable<MovieDto> FilterBy(Func<MovieDto, bool> filter)
        {
            var moviedtos = _movierepository.GetAll().Select(_mapper.Map<Movie, MovieDto>);
            return moviedtos.Where(filter);
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

        public IEnumerable<MovieDto> GetByUser(int userId)
        {
            var movies = _movierepository.FilterBy(x => x.UserId == userId).Select(_mapper.Map<Movie, MovieDto>);
            return movies;
        }

        public void Update(UpdateMovieDto entity, int id)
        {
            var movie = _movierepository.Update(_mapper.Map<Movie>(entity));
        }
    }
}
