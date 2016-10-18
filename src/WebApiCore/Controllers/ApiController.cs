using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiCore.Controllers
{
    public class ApiController : Controller
    {
        // GET: /<controller>/
        public IActionResult Get()
        {
            var rootObject = new
            {
                Class = "IMDMB",
                Properties = new
                {
                    Name = "IMDMB API",
                    Description = "API for the IM Dumb Movie Database",
                    Version = "1.0",
                    License = "LGPL-3.0"
                },
                Links = new[] {
                    new
                    {
                        Rel = "movies",
                        Href = "http://localhost:5000/api/movies"
                    },
                    new
                    {
                        Rel = "actors",
                        Href = "http://localhost:5000/api/actors"
                    }
                }
            };
            return Ok(rootObject);
        }
    }
}
