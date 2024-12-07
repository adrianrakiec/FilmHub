using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController(IMovieRepository movieRepository, IOmdbService omdbService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovieById(int id)
        {
            var movie = await movieRepository.GetByIdAsync(id);

            if (movie == null)          
                return NotFound(); 

            return movie;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieDto createMovieDto)
        {
            if(createMovieDto.Title == null) 
                return BadRequest(new { message = "Title cannot be empty!" });
            
            var details = await omdbService.GetMovieDetailsAsync(createMovieDto.Title);
            var createdMovie = await movieRepository.CreateMovieAsync(createMovieDto, details!);

            return CreatedAtAction(nameof(GetMovieById), new { id = createdMovie.Id }, createdMovie);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateMovie(UpdateMovieDto updateMovieDto, int id)
        {
            var movie = await movieRepository.GetFullMovieByIdAsync(id);

            if (movie == null)
                return NotFound();

            if (updateMovieDto.IsWatched.HasValue)
            {
                movie.IsWatched = updateMovieDto.IsWatched.Value;
                movie.DateWatched = movie.IsWatched ? movie.DateWatched ?? DateTime.UtcNow : null;
            }

            if (updateMovieDto.UserNotes != movie.UserNotes)
            {
                movie.UserNotes = updateMovieDto.UserNotes;
            }

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

            return BadRequest(new { message = "problem during deletion!" });
        }
    }
}
