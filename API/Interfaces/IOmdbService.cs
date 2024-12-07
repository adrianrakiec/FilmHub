using API.Entities;

namespace API.Interfaces;

public interface IOmdbService
{
    Task<MovieMetadata?> GetMovieDetailsAsync(string title);
}
