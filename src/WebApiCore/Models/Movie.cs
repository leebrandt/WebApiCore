using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Models
{
    public class Movie
    {
        public Movie()
        {
            Actors = new List<Actor>();
        }
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public int RunTime { get; set; }
        public IList<Actor> Actors { get; set; }
    }
}
