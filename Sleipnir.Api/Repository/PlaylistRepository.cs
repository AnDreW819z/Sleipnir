using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sleipnir.Api.Data;
using Sleipnir.Api.Interfaces;
using Sleipnir.Api.Models;
using Sleipnir.Dtos.Auth;
using Sleipnir.Dtos.Playlist;

namespace Sleipnir.Api.Repository
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly DataContext _context;
        private UserManager<User> _userManager;
        public PlaylistRepository(DataContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Status> AddPerson(string userId, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                InvitedPerson invitePerson = new()
                {

                }
            }
        }

        public async Task<Playlist> CreatePlaylist(string userId, CreatePlaylistDto dto)
        {
            Playlist newPlaylist = new() 
            {
                Id = dto.Id,
                OwnerId= userId,
                Name= dto.Name,
                ImageUrl= dto.ImageUrl,
                IsPublicPlaylist = dto.IsPublicPlaylist
            };
            if(newPlaylist !=null )
            {
                var result = await _context.Playlists.AddAsync( newPlaylist );
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            return default;

        }

        public Task<Status> DeletePlaylist(long playlistId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Playlist>> GetIWasAddedPlaylists(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Playlist>> GetMyPlaylists(string userId)
        {
            var MyPlaylists = await _context.Playlists.Where(u => u.OwnerId == userId).ToListAsync();
            if(MyPlaylists != null)
            {
                return MyPlaylists;
            }
            return default;
        }

        public Task<Playlist> GetPlaylistById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
