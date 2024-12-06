using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class MovieRepository(DataContext context) : IMovieRepository
{
    public async Task<IEnumerable<Movie>> GetMovies()
    {
        return await context.Movies.ToListAsync();
    }
}
