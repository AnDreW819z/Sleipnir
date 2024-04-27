using Microsoft.EntityFrameworkCore;
using Sleipnir.Api.Data;
using Sleipnir.Api.Interfaces;
using Sleipnir.Api.Models;
using Sleipnir.Dtos.Music;

namespace Sleipnir.Api.Repository
{
    public class MusicRepository : IMusicRepository
    {
        private readonly DataContext _context;
        private readonly IArtistRepository _artist;
        private readonly IGenreRepository _genre;
        public MusicRepository(DataContext context, IArtistRepository artist, IGenreRepository genre)
        {
            _context = context;
            _artist = artist;
            _genre = genre;
        }
        private async Task<bool> MusicExist(string name)
        {
            return await _context.Musics.AnyAsync(p => p.Name == name);
        }
        public async Task<bool> MusicExist(long id)
        {
            return await _context.Musics.AnyAsync(p => p.Id == id);
        }

        public async Task<Music> AddNewMusic(CreateMusicDto dto)
        {
            if(!await MusicExist(dto.Name))
            {
                var artistIds = new List<long>();
                foreach(var artistId in dto.ArtistsIds)
                {
                    if(await _artist.ArtistExist(artistId))
                    {
                        artistIds.Add(artistId);
                    }
                }
                var genreIds = new List<long>();
                foreach(var genreId in dto.GenresIds)
                {
                    if(await _genre.GenreExist(genreId))
                    {
                        genreIds.Add(genreId);
                    }
                }
                if(artistIds.Count > 0 && genreIds.Count > 0)
                {
                    Music music = new()
                    {
                        Id = dto.Id,
                        Name = dto.Name,
                        ImageUrl = dto.ImageUrl,
                        Adress = dto.Adress
                    };
                    if(music != null)
                    {
                        var result = await _context.Musics.AddAsync(music);
                        await _context.SaveChangesAsync();
                        foreach (var artId in artistIds)
                        {
                            MusicArtist artist = new()
                            {
                                ArtistId = artId,
                                MusicId = result.Entity.Id,
                            };
                            var musicArtists = await _context.MusicArtists.AddAsync(artist);
                        }
                        foreach (var genId in genreIds)
                        {
                            MusicGenre genre = new()
                            {
                                GenreId = genId,
                                MusicId = result.Entity.Id,
                            };
                            var musicGenres = await _context.MusicGenres.AddAsync(genre);
                        }
                        await _context.SaveChangesAsync();
                        return result.Entity;
                    }
                }
            }
            return default;
        }

        public async Task<Music> GetById(long id)
        {
            var music = await _context.Musics.FindAsync(id);
            if(music != null)
            {
                music.Artists = await _context.MusicArtists.Where(m => m.MusicId == id).Include(a => a.Artist).ToListAsync();
                return music;
            }
            return default;
        }

        public Task<Music> DeleteMusic(long id)
        {
            throw new NotImplementedException();
        }
    }
}
