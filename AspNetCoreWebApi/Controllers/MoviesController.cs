using Microsoft.AspNetCore.Mvc;
using MovieWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieWebApi.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        // GET api/movies
        [HttpGet]
        public IList<Movie> Get()
        {
            IList<Movie> movies;

            using (var db = new MovieContext())
            {
                movies = db.Movies
                        .OrderBy(b => b.Title)
                        .ToList();
            }

            return movies;
        }

        // GET api/movies/5
        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            Movie movie;
            using (var db = new MovieContext())
            {
                movie = db.Movies.FirstOrDefault(a => a.Id == id);
            }

            return movie;
        }

        // POST api/movies
        [HttpPost]
        public void Post([FromBody]Movie value)
        {
            using (var db = new MovieContext())
            {
                var movie = new Movie
                {
                    Id = value.Id,
                    Title = value.Title,
                    ReleaseYear = value.ReleaseYear,
                    Director = value.Director,
                    Genre = value.Genre
                };

                db.Movies.Add(movie);
                db.SaveChanges();
            }
        }

        // PUT api/movies/5
        [HttpPut]
        public void Put([FromBody]Movie value)
        {
            using (var db = new MovieContext())
            {
                Movie movie = db.Movies.FirstOrDefault(m => m.Id == value.Id);
                if (movie != null)
                {
                    movie.Title = value.Title;
                    movie.ReleaseYear = value.ReleaseYear;
                    movie.Director = value.Director;
                    movie.Genre = value.Genre;

                    db.SaveChanges();
                }
            }
        }

        // DELETE api/movies/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var db = new MovieContext())
            {
                Movie movie = db.Movies.FirstOrDefault(a => a.Id == id);

                if (movie != null)
                {
                    db.Movies.Remove(movie);
                    db.SaveChanges();
                }
            }
        }
    }
}
