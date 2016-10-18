using System;
using System.Collections.Generic;
using System.Linq;
using WebApiCore.Models;

namespace WebApiCore.Data
{
    public class InMemoryMovieService : MovieService
    {
        public IEnumerable<Movie> GetAllMovies()
        {
            return Movies.AsEnumerable();
        }

        public Movie GetMovieById(int id)
        {
            return Movies
                .FirstOrDefault(m => m.ID == id);
        }

        public IEnumerable<Actor> GetAllActors()
        {
            return Movies
                .SelectMany(x => x.Actors)
                .Distinct();
        }

        public Actor GetActorById(int id)
        {
            return GetAllActors()
                .FirstOrDefault(a => a.ID == id);
        }

        public Movie AddMovie(Movie movie)
        {
            movie.ID = Movies.Count() + 1;
            Movies.Add(movie);
            return movie;
        }

        private IList<Movie> Movies
        {
            get
            {
                var tnlbrb = new Movie
                {
                    ID = 1,
                    Title = "Talladega Nights: The Ballad of Ricky Bobby",
                    Description = "#1 NASCAR driver Ricky Bobby stays atop the heap thanks to a pact with his best friend and teammate, Cal Naughton, Jr. But when a French Formula One driver, makes his way up the ladder, Ricky Bobby's talent and devotion are put to the test.",
                    Director = "Adam McKay",
                    Rating = "PG-13",
                    ReleaseYear = 2006,
                    RunTime = 108
                };

                var amlrb = new Movie
                {
                    ID = 2,
                    Title = "Anchorman: The Legend Of Ron Burgundy",
                    Description = "Ron Burgundy is San Diego's top-rated newsman in the male-dominated broadcasting of the 1970s, but that's all about to change for Ron and his cronies when an ambitious woman is hired as a new anchor.",
                    Director = "Adam McKay",
                    Rating = "PG-13",
                    ReleaseYear = 2004,
                    RunTime = 94
                };

                var willF = new Actor
                {
                    ID = 1,
                    Name = "Will Ferrell",
                    Movies = new List<Movie> { tnlbrb, amlrb }
                };

                var johnR = new Actor
                {
                    ID = 2,
                    Name = "John C. Reilly",
                    Movies = new List<Movie> { tnlbrb }
                };

                var steveC = new Actor
                {
                    ID = 3,
                    Name = "Steve Carell",
                    Movies = new List<Movie> { amlrb }
                };

                var rudd = new Actor
                {
                    ID = 4,
                    Name = "JD Rudd",
                    Movies = new List<Movie> { amlrb }
                };

                tnlbrb.Actors = new List<Actor> { willF, johnR };
                amlrb.Actors = new List<Actor> { willF, steveC, rudd };

                return new List<Movie> { tnlbrb, amlrb };
            }
            
        }
    }
}
