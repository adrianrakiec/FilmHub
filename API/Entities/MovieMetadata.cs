namespace API.Entities;

public class MovieMetadata
{
    public int Id { get; set; }
    public string? ImdbId { get; set; }
    public string? Type { get; set; }
    public string? Year { get; set; }
    public string? PosterUrl { get; set; }
    public string? Plot { get; set; }
    public string? Actors { get; set; } 
    public string? Director { get; set; }
    public string? Writer { get; set; } 
    public string? Genre { get; set; } 
    public string? Awards { get; set; } 
    public string? Ratings { get; set; } 
    public DateTime LastUpdated { get; set; } 
    public Movie Movie { get; set; } = null!;
    public int MovieId { get; set; }
}
