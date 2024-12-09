using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController(IMovieRepository movieRepository, IOmdbService omdbService) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<MovieDto>> GetMovies()
        {
            var movies = await movieRepository.GetMoviesAsync();

            return movies;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovieById(int id)
        {
            var movie = await movieRepository.GetByIdAsync(id);

            if (movie == null)          
                return NotFound(); 

            return movie;
        }

        [HttpGet("search")]
        public async Task<ActionResult<OmdbSearchResponse?>> SearchMovies(string query, int page)
        {
            var results = await omdbService.SearchMoviesAsync(query, page);

            if(results?.Search == null)
                return NotFound(new { message = "No matching results"});

            return results;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieDto createMovieDto)
        {
            if(createMovieDto.Title == null) 
                return BadRequest(new { message = "Title cannot be empty!" });
            
            var details = await omdbService.GetMovieDetailsAsync(createMovieDto.Title);
            var createdMovie = await movieRepository.CreateMovieAsync(createMovieDto, details!);

            if(details?.ImdbId == null)
                return BadRequest(new { message = "No such movie!" });

            return CreatedAtAction(nameof(GetMovieById), new { id = createdMovie.Id }, createdMovie);
        }

        [HttpPatch("note/{id}")]
        public async Task<IActionResult> UpdateMovieNotes(string note, int id)
        {
            var movie = await movieRepository.GetFullMovieByIdAsync(id);

            if (movie == null)
                return NotFound();

            movie.UserNotes = note;
            
            if(await movieRepository.SaveAllAsync())
                return NoContent();

            return BadRequest(new { message = "Problem with saving!" });
        }

        [HttpPatch("edit-viewed/{id}")]
        public async Task<IActionResult> UpdateMovie(int id)
        {
            var movie = await movieRepository.GetFullMovieByIdAsync(id);

            if (movie == null)
                return NotFound();

            movie.IsWatched = true;
            movie.DateWatched = DateTime.UtcNow;

            if(await movieRepository.SaveAllAsync())
                return NoContent();

            return BadRequest(new { message = "Problem with saving!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await movieRepository.GetFullMovieByIdAsync(id);

            if (movie == null)
                return NotFound(new { message = "Movie not found" });

            movieRepository.DeleteMovie(movie);

            if(await movieRepository.SaveAllAsync())
                return NoContent();

            return BadRequest(new { message = "Problem during deletion!" });
        }
    }
}
