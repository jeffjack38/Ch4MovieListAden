using Microsoft.AspNetCore.Mvc;
using Ch4MovieListAden.Models;
using System.Diagnostics;

namespace Ch4MovieListAden.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext context {  get; set; }
        
        public HomeController(MovieContext ctx) { 
            context = ctx;
        }

        public IActionResult Index()
        {
            var movies = context.Movies.OrderBy(m => m.Name).ToList();  
            return View(movies);
        }
    }
}
