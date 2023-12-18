using CleanMovie.Application;
using CleanMovie.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanMovie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("getAllMovies")]
        public ActionResult<List<Movie>> Get()
        {
            return Ok( _movieService.getAllMovie());

        }


        [HttpPost("addMovie")]

        public ActionResult<Movie> addmovie(Movie m) 
        {
            _movieService.createMovie(m);
            return Ok(m);
        }
    }
}
