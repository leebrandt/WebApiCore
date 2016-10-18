using System.Collections.Generic;
using WebApiCore.Models;

namespace WebApiCore.Data
{
    public interface MovieService
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        IEnumerable<Actor> GetAllActors();
        Actor GetActorById(int id);
        Movie AddMovie(Movie movie);
    }
}
