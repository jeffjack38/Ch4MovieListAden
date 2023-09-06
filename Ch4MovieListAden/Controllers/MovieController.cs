using Microsoft.AspNetCore.Mvc;
using Ch4MovieListAden.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Ch4MovieListAden.Controllers
{
    public class MovieController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private MovieContext context { get; set; }

        public MovieController(ILogger<HomeController> logger, MovieContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var movies = context.Movies
                .Include(n => n.Genre)
                .OrderBy(n => n.Name)
                .ToList();

            return View(movies);
        }

        public IActionResult Edit(int id)
        {

            ViewBag.Genres = context.Genres.ToList();
            ViewBag.Action = "Edit";

            var movie = context.Movies
                .Include(n => n.Genre)
                .Where(n => n.MovieId == id)
                .FirstOrDefault();

            return View(movie);
        }
    }
}
