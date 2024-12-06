namespace API.Entities;

public class Movie
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public bool IsWatched { get; set; } = false;
    public DateTime? DateWatched { get; set; } 
    public string? UserNotes { get; set; }
    public MovieMetadata? Metadata { get; set; }
}
