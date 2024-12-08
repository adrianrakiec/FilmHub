using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class MovieRepository(DataContext context, IMapper mapper) : IMovieRepository
{
    public async Task<IEnumerable<MovieDto>> GetMoviesAsync()
    {
        return await context.Movies
            .Include(x => x.Metadata)
            .ProjectTo<MovieDto>(mapper.ConfigurationProvider)
            .ToListAsync();
    }
    
    public async Task<MovieDto?> GetByIdAsync(int id)
    {
        return await context.Movies
            .Include(x => x.Metadata)
            .ProjectTo<MovieDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<MovieDto> CreateMovieAsync(CreateMovieDto createMovieDto, MovieMetadata movieMetadata)
    {
        var movie = new Movie
        {
            Title = createMovieDto.Title!,
            UserNotes = createMovieDto.UserNotes
        };

        movieMetadata.LastUpdated = DateTime.Now;
        movie.Metadata = movieMetadata;

        context.Movies.Add(movie);
        await context.SaveChangesAsync();

        return mapper.Map<MovieDto>(movie);
    }

    public async Task<Movie?> GetFullMovieByIdAsync(int id)
    {
        return await context.Movies.FindAsync(id);
    }

    public async Task<bool> SaveAllAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void DeleteMovie(Movie movie)
    {
        context.Movies.Remove(movie);
    }
}
