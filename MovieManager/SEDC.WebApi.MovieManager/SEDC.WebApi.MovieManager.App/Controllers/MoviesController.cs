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
                return Ok(_movieService.FilterBy(x => x.Genre.Equals(genre, StringComparison.InvariantCultureIgnoreCase)));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("year/{filter}")]
        public ActionResult GetByYear(string filter)
        {
            try
            {
                int year = int.Parse(filter);
                return Ok(_movieService.FilterBy(x => x.Year == year));
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

        public ActionResult Delete(MovieDto movieDto)
        {
            try
            {
                _movieService.Delete(movieDto);
                return Ok("The movie has been deleted");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
