﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index(int? pageIndex , string sortBy)
        {
            Movie movie = new Movie()
            {
                Id = 1,
                Name = "Avengers"
            };
            return View(movie);

        }
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content($"Year={year} and Month={month}");
        }

    }
}