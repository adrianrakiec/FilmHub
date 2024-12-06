using API.DTOs;

namespace API.Interfaces;

public interface IMovieRepository
{
    Task<MovieDto?> GetByIdAsync(int id);
    Task<MovieDto> CreateMovieAsync(CreateMovieDto createMovieDto);
}
