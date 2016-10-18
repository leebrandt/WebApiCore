using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Models;

namespace WebApiCore.Decorators
{
    public static class MovieListDecorator
    {
        public static object Decorate (IList<Movie> movies)
        {
            var movieList = new
            {
                Class = "Movie List",
                Properties = new
                {
                    itemCount = movies.Count()
                },
                Entities = new List<object>(),
                Links = new object[]
                {
                    new
                    {
                        Rel = "root",
                        Href = "http://localhost:5000/api"
                    }
                }
            };

            foreach (var movie in movies)
            {
                movieList.Entities.Add(decorateMovie(movie));
            }

            return movieList;
        }

        private static object decorateMovie(Movie movie)
        {
            return new
            {
                Class = "Movie",
                Properties = new {
                    Title = movie.Title,
                    Rating = movie.Rating,
                    Runtime = movie.RunTime
                },
                Links = new object[] 
                {
                    new
                    {
                        Rel = "detail",
                        Href = $"http://localhost:5000/api/movies/{movie.ID}"
                    },
                    new
                    {
                        Rel = "root",
                        Href = "http://localhost:5000/api"
                    }
                }
            };
        }
    }
}
