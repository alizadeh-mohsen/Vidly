using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            Movie movie = new Movie()
            {
                Id = 1,
                Name = "Avengers"
            };
            return View(movie);
        }
    }
}