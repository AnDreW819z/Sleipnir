using Sleipnir.Api.Models;
using Sleipnir.Dtos.Auth;
using Sleipnir.Dtos.FollowMusic;

namespace Sleipnir.Api.Interfaces
{
    public interface IFollowMusicRepository
    {
        public Task<FollowMusic> AddFollowMusic(string userId, long musicId);
        public Task<Status> DeleteFollowMusic(string userId, long id);
        public Task<List<FollowMusic>> GetFollowMusics(string userId);
    }
}
