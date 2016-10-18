using System.Collections.Generic;
using WebApiCore.Models;

namespace WebApiCore.Decorators
{
    public static class MovieDecorator
    {
        public static object Decorate(Movie movie)
        {
            var movieDetails =  new
            {
                Class = "Movie",
                Properties = new
                {
                    Title = movie.Title,
                    Description = movie.Description,
                    Director = movie.Director,
                    ReleaseYear = movie.ReleaseYear,
                    Rating = movie.Rating,
                    Runtime = movie.RunTime,
                    Cast = new List<object>()
                },
                Links = new object[]
                {
                    new
                    {
                        Rel = "parent",
                        Href = "http://localhost:5000/api/movies"
                    },
                    new
                    {
                        Rel = "root",
                        Href = "http://localhost:5000/api"
                    }
                }
            };

            foreach (var actor in movie.Actors)
            {
                movieDetails.Properties.Cast.Add(DecorateCastMember(actor));
            }


            return movieDetails;
        }

        private static object DecorateCastMember(Actor actor)
        {
            return new
            {
                Class = "Actor",
                Properties = new {
                    Name = actor.Name
                },
                Links = new object[] 
                {
                    new
                    {
                        Rel = "details",
                        Href = $"http://localhost:5000/api/actors/{actor.ID}"
                    },
                    new
                    {
                        Rel = "parent",
                        Href = "http://localhost:5000/api/actors"
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
