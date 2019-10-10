using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context=new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            List<Movie> movies;
            using (_context)
            {
                movies = _context.Movies.Include(m=>m.Genre).ToList();
            }
            return View(movies);

        }

        [Route("Movies/Release/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content($"Year={year} and Month={month}");
        }

        public ActionResult RandomMovies()
        {
            RandomMovieViewModel viewModel = new RandomMovieViewModel()
            {
                Movie = new Movie()
                {
                    Id = 1,
                    Name = "Avengers"
                },
                Customers = new List<Customer>()
                {
                    new Customer {Name = "Customer 1"},
                    new Customer {Name = "Customer 2"},

                }
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            Movie movie;
            using (_context)
            {
                movie =_context.Movies.Include(m=>m.Genre).SingleOrDefault(m => m.Id == id);
            }

            return View(movie);
        }
    }
}