using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface IOmdbService
{
    Task<MovieMetadata?> GetMovieDetailsAsync(string title);
    Task<OmdbSearchResponse?> SearchMoviesAsync(string query, int page);
}
