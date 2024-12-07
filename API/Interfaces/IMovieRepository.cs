using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface IMovieRepository
{
    Task<MovieDto?> GetByIdAsync(int id);
    Task<MovieDto> CreateMovieAsync(CreateMovieDto createMovieDto, MovieMetadata movieMetadata);
}
