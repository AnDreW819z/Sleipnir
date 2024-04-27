using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sleipnir.Api.Extensions;
using Sleipnir.Api.Interfaces;
using Sleipnir.Api.Models;
using Sleipnir.Dtos.Artist;
using Sleipnir.Dtos.Auth;
using Sleipnir.Dtos.Genre;

namespace Sleipnir.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genre;
        public GenreController(IGenreRepository genre)
        {
            _genre = genre;
        }

        [HttpGet]
        [Route("getGenres")]
        public async Task<ActionResult<List<GetGenresDto>>> GetGenres()
        {
            try
            {
                var genres = await _genre.GetGenres();
                if (genres == null)
                {
                    return NotFound();
                }
                else
                {
                    var genreDto = genres.ConvertToDto();
                    return Ok(genreDto);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ошибка получения данных из базы данных");
            }
        }

        [HttpGet]
        [Route("getGenre/{id:long}")]
        public async Task<ActionResult<GenreDto>> GetGenre(long id)
        {
            try
            {
                var genre = await _genre.GetGenre(id);
                if (genre == null)
                {
                    return NotFound();
                }
                else
                {
                    var genreDto = genre.ConverToDto();
                    return Ok(genreDto);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ошибка получения данных из базы данных");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewGenre([FromBody] CreateGenreDto dto)
        {
            try
            {
                var newGenre = await _genre.AddNewGenre(dto);
                if (newGenre == null)
                {
                    return NoContent();
                }
                return Ok(newGenre);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ошибка создания");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Status>> DeleteGenre(long id)
        {
            try
            {
                var genre = await _genre.DeleteGenre(id);
                return genre;
            }
            catch (Exception ex)
            {
                return new Status { Message = ex.Message, StatusCode = 500 };
            }
        }
    }
}
