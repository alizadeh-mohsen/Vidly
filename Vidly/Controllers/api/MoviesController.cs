using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.Include(m=>m.Genre).ToList();
        }

        public Movie GetMovie(int id)
        {
            return _context.Movies.SingleOrDefault(m => m.Id == id);
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }

            var newMovie = _context.Movies.Add(movie);
            return Created(new Uri(Request.RequestUri + "/" + newMovie.Id), newMovie);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id,Movie movie)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            var dbMovie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (dbMovie == null)
            {
                NotFound();
            }
            dbMovie.DateAdded = movie.DateAdded;
            dbMovie.GenreId = movie.GenreId;
            dbMovie.Name = movie.Name;
            _context.SaveChanges();
            return ApiController.ok
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var dbMovie = _context.Movies.SingleOrDefault(m => m.Id == id);
            _context.Movies.Remove(dbMovie);
            _context.SaveChanges();
            return Ok();
        }


    }
}
