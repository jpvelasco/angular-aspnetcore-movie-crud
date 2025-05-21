using Microsoft.EntityFrameworkCore;

namespace MovieWebApi.Models
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }
    }
}
