using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            Movie movie = new Movie()
            {
                Id = 1,
                Name = "Avengers"
            };
            return View(movie);

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

    }
}