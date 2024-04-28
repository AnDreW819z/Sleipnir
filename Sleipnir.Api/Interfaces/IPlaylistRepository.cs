using Sleipnir.Api.Models;
using Sleipnir.Dtos.Auth;
using Sleipnir.Dtos.Playlist;

namespace Sleipnir.Api.Interfaces
{
    public interface IPlaylistRepository
    {
        public Task<Playlist> CreatePlaylist(string userId, CreatePlaylistDto dto);
        public Task<Status> DeletePlaylist(long playlistId, string userId);
        public Task<Playlist> GetPlaylistById(long id);
        public Task<List<Playlist>> GetMyPlaylists(string userId);
        public Task<List<Playlist>> GetIWasAddedPlaylists(string email);
        public Task<Status> AddPerson(string userId, string email, long playlistId);
    }
}
