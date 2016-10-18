using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Data;
using WebApiCore.Models;
using WebApiCore.Decorators;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private MovieService _movieService;

        public MoviesController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var movies = _movieService.GetAllMovies().ToList();
            return Ok(MovieListDecorator.Decorate(movies));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var returnMovie = _movieService.GetMovieById(id);
            if (returnMovie == null)
            {
                return NotFound($"Movie with id of {id} was not found.");
            }
            return Ok(MovieDecorator.Decorate(returnMovie));
        }

        [HttpPost]
        public IActionResult Save([FromBody]Movie movie)
        {
            _movieService.AddMovie(movie);
            return CreatedAtAction("GetById", new { id = movie.ID }, MovieDecorator.Decorate(movie));
        }

    }
}
