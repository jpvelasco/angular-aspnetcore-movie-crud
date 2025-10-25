namespace MovieWebApi.Models;

public class Movie
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string ReleaseYear { get; set; }
    public required string Director { get; set; }
    public required string Genre { get; set; }
}
