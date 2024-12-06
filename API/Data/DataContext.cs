using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieMetadata> MovieDetails { get; set; }
}
