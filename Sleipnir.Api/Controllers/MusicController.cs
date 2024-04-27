using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sleipnir.Api.Interfaces;
using Sleipnir.Api.Models;
using Sleipnir.Dtos.Genre;
using Sleipnir.Dtos.Music;

namespace Sleipnir.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicRepository _music;
        public MusicController(IMusicRepository music)
        {
            _music = music;
        }


        [HttpPost]
        public async Task<IActionResult> AddNewMusic([FromBody] CreateMusicDto dto)
        {
            try
            {
                var newMusic = await _music.AddNewMusic(dto);
                if (newMusic == null)
                {
                    return NoContent();
                }
                return Ok(newMusic);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ошибка создания");
            }
        }
    }
}
