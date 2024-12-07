namespace API.DTOs;

public class OmdbSearchResponse
{
    public List<MovieSearchResult>? Search { get; set; }
    public string? TotalResults { get; set; }
    public string? Response { get; set; }
}
