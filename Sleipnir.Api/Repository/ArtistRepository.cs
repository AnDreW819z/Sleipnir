using Microsoft.EntityFrameworkCore;
using Sleipnir.Api.Data;
using Sleipnir.Api.Interfaces;
using Sleipnir.Api.Models;
using Sleipnir.Dtos.Artist;
using Sleipnir.Dtos.Auth;

namespace Sleipnir.Api.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly DataContext _context;
        public ArtistRepository(DataContext context)
        {
            _context = context;
        }

        private async Task<bool> ArtistExist(string name)
        {
            return await _context.Artists.AnyAsync(p => p.Name == name);
        }
        public async Task<bool> ArtistExist(long id)
        {
            return await _context.Artists.AnyAsync(p => p.Id == id);
        }

        public async Task<Artist> AddNewArtist(CreateArtistDto dto)
        {
            if (!await ArtistExist(dto.Name))
            {
                Artist artist = new()
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    ImageUrl = dto.ImageUrl,
                    Description = dto.Description,
                    UserId = dto.UserId
                };

                if (artist != null)
                {
                    var result = await _context.Artists.AddAsync(artist);
                    await _context.SaveChangesAsync();
                    return result.Entity;
                }
            }
            return default;
        }

        public async Task<Status> DeleteArtist(long id)
        {
            Artist artist = await _context.Artists.FindAsync(id);
            if (artist != null)
            {
                _context.Artists.Remove(artist);
                await _context.SaveChangesAsync();
                return new Status { Message = "Исполнитель успешно удалено", StatusCode = 200 };
            }
            return new Status { Message = "Ошибка удаления", StatusCode = 500 };
        }

        public async Task<List<Artist>> GetAllArtists()
        {
            var artists = await _context.Artists.ToListAsync();
            return artists;
        }

        public async Task<Artist> GetArtist(long id)
        {
            if(await ArtistExist(id))
            {
                var artist = await _context.Artists.FindAsync(id);
                artist.Musics = await _context.MusicArtists.Where(a => a.ArtistId== id).Include(a=>a.Music).ToListAsync();
                var musicList = new List<MusicArtist>();
                foreach(var m in artist.Musics)
                {
                    var mus = (await _context.MusicArtists.Where(_ => _.MusicId== m.MusicId).Include(a => a.Artist).ToListAsync());
                    musicList.Add( mus.Where(x => x.MusicId == m.MusicId).FirstOrDefault());
                }
                artist.Musics = musicList;
                return artist;
            }
            return default;
        }
    }
}
