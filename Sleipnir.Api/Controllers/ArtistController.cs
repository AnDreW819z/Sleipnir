using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sleipnir.Api.Extensions;
using Sleipnir.Api.Interfaces;
using Sleipnir.Dtos.Artist;
using Sleipnir.Dtos.Auth;

namespace Sleipnir.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository _artist;
        public ArtistController(IArtistRepository artist)
        {
            _artist = artist;
        }

        [HttpGet]
        [Route("getArtists")]
        public async Task<ActionResult<List<MusicArtistsDto>>> GetArtists()
        {
            try
            {
                var artists = await _artist.GetAllArtists();
                if (artists == null)
                {
                    return NotFound();
                }
                else
                {
                    var artistDto = artists.ConvertToDtos();
                    return Ok(artistDto);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ошибка получения данных из базы данных");
            }
        }

        [HttpGet]
        [Route("getArtist/{id:long}")]
        public async Task<ActionResult<ArtistDto>> GetArtist(long id)
        {
            try
            {
                var artist = await _artist.GetArtist(id);
                if (artist == null)
                {
                    return NotFound();
                }
                else
                {
                    var artistDto = artist.ConverToDto();
                    return Ok(artistDto);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ошибка получения данных из базы данных");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewArtist([FromBody] CreateArtistDto dto)
        {
            try
            {
                var newArtist = await _artist.AddNewArtist(dto);
                if (newArtist == null)
                {
                    return NoContent();
                }
                return Ok(newArtist);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ошибка создания");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Status>> DeleteArtist(long id)
        {
            try
            {
                var artist = await _artist.DeleteArtist(id);
                return artist;
            }
            catch (Exception ex)
            {
                return new Status { Message = ex.Message, StatusCode = 500 };
            }
        }
    }
}
