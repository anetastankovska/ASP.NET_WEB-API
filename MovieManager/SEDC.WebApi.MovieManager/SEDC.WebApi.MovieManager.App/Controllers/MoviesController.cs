using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.MovieManager.DataModels.Enums;
using SEDC.WebApi.MovieManager.ServiceModels.MovieModels;
using SEDC.WebApi.MovieManager.Services.Interfaces;

namespace SEDC.WebApi.MovieManager.App.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var movies = _movieService.GetAll();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id/{id}")]
        public ActionResult<MovieDto> GetById(int id)
        {
            try
            {
                var movie = _movieService.GetById(id);
                return Ok(movie);
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }

        [HttpGet("genre/{genre}")]
        public ActionResult GetByGenre(string genre)
        {
            try
            {
                var movies = _movieService.FilterBy(x => x.Genre.Equals(genre, StringComparison.InvariantCultureIgnoreCase));
                if(movies == null)
                {
                    throw new Exception("Movies not found");
                }
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("year/{year}")]
        public ActionResult GetByYear(string year)
        {
            try
            {
                int parsedYear = int.Parse(year);
                var movies = _movieService.FilterBy(x => x.Year == parsedYear);
                if(movies == null)
                {
                    throw new Exception("There are no movies in the selected year.");
                }
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        //public ActionResult Add()
        //{

        //}

        //public ActionResult Update()
        //{

        //}

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                _movieService.Delete(id);
                return Ok($"The movie with id {id} has been deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
