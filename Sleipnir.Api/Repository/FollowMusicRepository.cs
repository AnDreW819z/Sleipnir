using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Sleipnir.Api.Data;
using Sleipnir.Api.Interfaces;
using Sleipnir.Api.Models;
using Sleipnir.Dtos.Auth;
using Sleipnir.Dtos.FollowMusic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sleipnir.Api.Repository
{
    public class FollowMusicRepository : IFollowMusicRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public FollowMusicRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private async Task<bool> FollowMusicExist(string userId, long musicId)
        {
            return await _context.FollowMusics.AnyAsync(u => u.UserId == userId && u.MusicId == musicId);
        }

        public async Task<FollowMusic> AddFollowMusic(string userId, long musicId)
        {
            if (!await FollowMusicExist(userId, musicId))
            {
                var music = await(from userMusic in _context.Musics
                                 where userMusic.Id == musicId
                                 select new FollowMusic
                                 {
                                     UserId = userId,
                                     MusicId = musicId,
                                 }).SingleOrDefaultAsync();

                if (music != null)
                {
                    var result = await _context.FollowMusics.AddAsync(music);
                    await _context.SaveChangesAsync();
                    return result.Entity;
                }
            }

            return default;
        }

        public async Task<Status> DeleteFollowMusic(string userId, long musucId)
        {
            if(await FollowMusicExist(userId, musucId))
            {
                var music = await _context.FollowMusics.Where(m => m.UserId == userId && m.MusicId == musucId).SingleAsync();
                _context.FollowMusics.Remove(music);
                await _context.SaveChangesAsync();
                return new Status { Message = "Аудиозапись успешно удалена из вашего плейлиста", StatusCode = 200 };
            }
            return new Status { Message = "Ошибка удаления", StatusCode = 500 };
        }

        public async Task<List<FollowMusic>> GetFollowMusics(string userId)
        {
            return await _context.FollowMusics.Where(_ => _.UserId == userId).ToListAsync();
        }

    }
}
