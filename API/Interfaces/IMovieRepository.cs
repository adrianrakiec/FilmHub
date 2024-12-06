using API.Entities;

namespace API.Interfaces;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetMovies();
}
