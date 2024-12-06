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
    public async Task<MovieDto?> GetByIdAsync(int id)
    {
        return await context.Movies
            .Include(x => x.Metadata)
            .ProjectTo<MovieDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<MovieDto> CreateMovieAsync(CreateMovieDto createMovieDto)
    {
        var movie = new Movie
        {
            Title = createMovieDto.Title!,
            UserNotes = createMovieDto.UserNotes
        };

        var metaData = new MovieMetadata
        {
            LastUpdated = DateTime.Now
        };

        movie.Metadata = metaData;

        context.Movies.Add(movie);
        await context.SaveChangesAsync();

        return mapper.Map<MovieDto>(movie);
    }
}
