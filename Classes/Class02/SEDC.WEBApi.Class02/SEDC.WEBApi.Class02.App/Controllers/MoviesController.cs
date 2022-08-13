using Microsoft.AspNetCore.Mvc;
using SEDC.WEBApi.Class02.App.Models;

namespace SEDC.WEBApi.Class02.App.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly List<Movie> _movies = new List<Movie>()
        {
            new Movie
            {
                Id = 1,
                Title = "Harry Potter",
                Year = 2000,
                Genre = Genre.ScienceFiction,
                Rating = 8
            },
            new Movie
            {
                Id = 2,
                Title = "The Lord of the Rings",
                Year = 2005,
                Genre = Genre.ScienceFiction,
                Rating = 10
            },
            new Movie
            {
                Id = 3,
                Title = "Scream",
                Year = 1990,
                Genre = Genre.Horror,
                Rating = 6
            },
            new Movie
            {
                Id = 4,
                Title = "Dumb and Dumber",
                Year = 2000,
                Genre = Genre.Comedy,
                Rating = 4
            },
            new Movie
            {
                Id = 5,
                Title = "Gone Girl",
                Year = 1006,
                Genre = Genre.Thriller,
                Rating = 7
            },
            new Movie
            {
                Id = 6,
                Title = "Hustle",
                Year = 2018,
                Genre = Genre.Drama,
                Rating = 10
            },
            new Movie
            {
                Id = 7,
                Title = "Terminator",
                Year = 1986,
                Genre = Genre.Thriller,
                Rating = 9
            },
            new Movie
            {
                Id = 8,
                Title = "Inglorious Bastards",
                Year = 1997,
                Genre = Genre.Drama,
                Rating = 10
            }
        };

        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            if (id < 1)
            {
                return BadRequest(id);
            }
            var movie = _movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return NotFound($"The user does not exists");
            }
            return Ok(movie);
        }

        [HttpGet("title/{title}")]
        public ActionResult<IEnumerable<Movie>> GetMovieByTitle(string title)
        {
            var movies = _movies.Where(x => x.Title.
                Equals(title, StringComparison.InvariantCultureIgnoreCase));
            return Ok(movies);
        }

        [HttpGet("from/{from}/to/{to}")]
        public ActionResult<IEnumerable<Movie>> GetMoviesBetweenYears(int from, int to)
        {
            var movies = _movies.Where(x => x.Year >= from && x.Year <= to);
            return Ok(movies);
        }

        [HttpGet("genre/{genre}/year/{year}")]
        public ActionResult<IEnumerable<Movie>> GetMoviesByGenreAndYear(Genre genre, int year)
        {
            var movies = _movies.Where(x => x.Genre == genre && x.Year == year);
            return Ok(movies);
        }

        [HttpGet("rating/{rating}/from/{from}")]
        public ActionResult<IEnumerable<Movie>> GetMovieByRating(int rating, int from, int to)
        {
            var movies = _movies.Where(x => x.Rating == rating & (x.Year >= from && x.Year <= to));
            return Ok(movies);
        }
    }
}
