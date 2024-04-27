using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sleipnir.Api.Interfaces;
using Sleipnir.Dtos.FollowMusic;
using System.Security.Claims;
using Sleipnir.Api.Extensions;
using Sleipnir.Api.Models;

namespace Sleipnir.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowMusicController : ControllerBase
    {
        private readonly IFollowMusicRepository _follow;
        private readonly IMusicRepository _music;
        public FollowMusicController(IFollowMusicRepository follow, IMusicRepository music)
        {
            _follow = follow;
            _music = music;
        }

        [HttpGet]
        [Authorize]
        [Route("GetUserFollowMusics")]
        public async Task<ActionResult<List<FollowMusicDto>>> GetFollows()
        {
            try
            {
                var userId = User.Claims.Where(x => x.Type == "id").FirstOrDefault()?.Value;
                var followMusics = _follow.GetFollowMusics(userId).Result;
                if (followMusics != null)
                {
                    var musics = new List<Music>();
                    foreach (var followMusic in followMusics)
                    {
                        var music = await _music.GetById(followMusic.MusicId);
                        if (music != null)
                        {
                            musics.Add(music);
                        }
                    }
                    List<FollowMusicDto> dto = followMusics.ConvertToDtos(musics);
                    return Ok(dto);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("AddFollowMusic/{musicId:long}")]
        public async Task<IActionResult> AddFollowMusic(long musicId)
        {
            try
            {
                var userId = User.Claims.Where(x => x.Type == "id").FirstOrDefault()?.Value;
                var newFollowMusic = await _follow.AddFollowMusic(userId, musicId);
                if(newFollowMusic != null)
                {
                    return Ok("аудиозапись успешно добавлена в Избранное");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{musicId:long}")]
        [Authorize]
        public async Task<IActionResult> DeleteFollowMusic(long musicId)
        {
            try
            {
                var userId = User.Claims.Where(x => x.Type == "id").FirstOrDefault()?.Value;
                var result = await _follow.DeleteFollowMusic(userId,musicId);
                if(result != null)
                    return Ok("аудиозапись успешно удалена из Избранного");
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetToken()
        {
            var email = User.Claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault()?.Value;
            var userid = User.Claims.Where(x => x.Type == "id").FirstOrDefault()?.Value;
            return Ok($"id ={userid}, email = {email}");
        }
    }
}
