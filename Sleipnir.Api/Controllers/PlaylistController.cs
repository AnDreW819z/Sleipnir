using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sleipnir.Api.Extensions;
using Sleipnir.Api.Interfaces;
using Sleipnir.Dtos.Playlist;

namespace Sleipnir.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistRepository _playlist;
        public PlaylistController(IPlaylistRepository playlist)
        {
            _playlist = playlist;
        }

        [Authorize]
        [HttpPost]
        [Route("CreatePlaylist")]
        public async Task<IActionResult> CreatePlaylist(CreatePlaylistDto dto)
        {
            try
            {
                var userId = User.Claims.Where(x => x.Type == "id").FirstOrDefault()?.Value;
                var newPlaylist = await _playlist.CreatePlaylist(userId, dto);
                if (newPlaylist != null)
                {
                    return Ok("Плейлист создан");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetMyPlaylists")]
        public async Task<IActionResult> GetMyPlaylists()
        {
            try
            {
                var userId = User.Claims.Where(x => x.Type == "id").FirstOrDefault()?.Value;
                var myPlaylists = await _playlist.GetMyPlaylists(userId);
                return Ok(myPlaylists.ConvertToDtos());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
