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
            var createdMovie = await movieRepository.CreateMovieAsync(createMovieDto, details);

            return CreatedAtAction(nameof(GetMovieById), new { id = createdMovie.Id }, createdMovie);
        }
    }
}
