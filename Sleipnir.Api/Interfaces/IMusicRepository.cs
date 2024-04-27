using Sleipnir.Api.Models;
using Sleipnir.Dtos.Music;

namespace Sleipnir.Api.Interfaces
{
    public interface IMusicRepository
    {
        public Task<Music> AddNewMusic(CreateMusicDto dto);
        public Task<Music> DeleteMusic(long id);
    }
}
