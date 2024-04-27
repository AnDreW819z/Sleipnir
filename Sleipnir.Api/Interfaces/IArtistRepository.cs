using Sleipnir.Api.Models;
using Sleipnir.Dtos.Artist;
using Sleipnir.Dtos.Auth;

namespace Sleipnir.Api.Interfaces
{
    public interface IArtistRepository
    {
        public Task<List<Artist>> GetAllArtists();
        public Task<Artist> GetArtist(long Id);
        public Task<Artist> AddNewArtist(CreateArtistDto dto);
        public Task<Status> DeleteArtist(long Id);
        public Task<bool> ArtistExist(long id);
    }
}
