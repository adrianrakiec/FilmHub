using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface IMovieRepository
{
    Task<IEnumerable<MovieDto>> GetMoviesAsync();
    Task<Movie?> GetFullMovieByIdAsync(int id);
    Task<MovieDto?> GetByIdAsync(int id);
    Task<MovieDto> CreateMovieAsync(CreateMovieDto createMovieDto, MovieMetadata movieMetadata);
    void DeleteMovie(Movie movie);
    Task<bool> SaveAllAsync();
}
