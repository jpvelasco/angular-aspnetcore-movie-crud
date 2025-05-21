using Microsoft.AspNetCore.Mvc;
using MovieWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieWebApi.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly MovieContext _db;

        public MoviesController(MovieContext context)
        {
            _db = context;
        }

        // GET api/movies
        [HttpGet]
        public IList<Movie> Get()
        {
            IList<Movie> movies;

            movies = _db.Movies
                    .OrderBy(b => b.Title)
                    .ToList();

            return movies;
        }

        // GET api/movies/5
        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            Movie movie;
            movie = _db.Movies.FirstOrDefault(a => a.Id == id);

            return movie;
        }

        // POST api/movies
        [HttpPost]
        public void Post([FromBody]Movie value)
        {
            var movie = new Movie
            {
                Id = value.Id,
                Title = value.Title,
                ReleaseYear = value.ReleaseYear,
                Director = value.Director,
                Genre = value.Genre
            };

            _db.Movies.Add(movie);
            _db.SaveChanges();
        }

        // PUT api/movies/5
        [HttpPut]
        public void Put([FromBody]Movie value)
        {
            Movie movie = _db.Movies.FirstOrDefault(m => m.Id == value.Id);
            if (movie != null)
            {
                movie.Title = value.Title;
                movie.ReleaseYear = value.ReleaseYear;
                movie.Director = value.Director;
                movie.Genre = value.Genre;

                _db.SaveChanges();
            }
        }

        // DELETE api/movies/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Movie movie = _db.Movies.FirstOrDefault(a => a.Id == id);

            if (movie != null)
            {
                _db.Movies.Remove(movie);
                _db.SaveChanges();
            }
        }
    }
}
