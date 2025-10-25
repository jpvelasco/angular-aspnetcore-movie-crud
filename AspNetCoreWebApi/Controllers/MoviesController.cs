using Microsoft.AspNetCore.Mvc;
using MovieWebApi.Models;

namespace MovieWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController(MovieContext context) : Controller
{
    // GET api/movies
    [HttpGet]
    public IEnumerable<Movie> Get()
    {
        return context.Movies
                .OrderBy(b => b.Title)
                .ToList();
    }

    // GET api/movies/5
    [HttpGet("{id}")]
    public ActionResult<Movie> Get(int id)
    {
        var movie = context.Movies.FirstOrDefault(a => a.Id == id);

        if (movie == null)
        {
            return NotFound();
        }

        return movie;
    }

    // POST api/movies
    [HttpPost]
    public IActionResult Post([FromBody] Movie value)
    {
        var movie = new Movie
        {
            Id = value.Id,
            Title = value.Title,
            ReleaseYear = value.ReleaseYear,
            Director = value.Director,
            Genre = value.Genre
        };

        context.Movies.Add(movie);
        context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
    }

    // PUT api/movies/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Movie value)
    {
        if (id != value.Id)
        {
            return BadRequest();
        }

        var movie = context.Movies.FirstOrDefault(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }

        movie.Title = value.Title;
        movie.ReleaseYear = value.ReleaseYear;
        movie.Director = value.Director;
        movie.Genre = value.Genre;

        context.SaveChanges();
        return NoContent();
    }

    // DELETE api/movies/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var movie = context.Movies.FirstOrDefault(a => a.Id == id);

        if (movie == null)
        {
            return NotFound();
        }

        context.Movies.Remove(movie);
        context.SaveChanges();
        return NoContent();
    }
}
