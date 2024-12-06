namespace API.DTOs;

public class MovieDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool? IsWatched { get; set; }
    public DateTime? DateWatched { get; set; } 
    public string? UserNotes { get; set; }
    public MovieMetadataDto? Metadata { get; set; }
}
