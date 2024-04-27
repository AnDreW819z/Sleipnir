using Microsoft.EntityFrameworkCore;
using Sleipnir.Api.Data;
using Sleipnir.Api.Interfaces;
using Sleipnir.Api.Models;
using Sleipnir.Dtos.Auth;
using Sleipnir.Dtos.Genre;

namespace Sleipnir.Api.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _context;
        public GenreRepository(DataContext context)
        {
            _context = context;
        }

        private async Task<bool> GenreExist(string name)
        {
            return await _context.Genres.AnyAsync(p => p.Name == name);
        }
        public async Task<bool> GenreExist(long id)
        {
            return await _context.Genres.AnyAsync(p => p.Id == id);
        }
        public async Task<Genre> AddNewGenre(CreateGenreDto dto)
        {
            if (!await GenreExist(dto.Name))
            {
                Genre genre = new()
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    ImageUrl = dto.ImageUrl,    
                };

                if (genre != null)
                {
                    var result = await _context.Genres.AddAsync(genre);
                    await _context.SaveChangesAsync();
                    return result.Entity;
                }
            }
            return default;
        }

        public async Task<Status> DeleteGenre(long id)
        {
            Genre genre = await _context.Genres.FindAsync(id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                await _context.SaveChangesAsync();
                return new Status { Message = "Жанр успешно удалено", StatusCode = 200 };
            }
            return new Status { Message = "Ошибка удаления", StatusCode = 500 };
        }

        public async Task<Genre> GetGenre(long id)
        {
            if (await GenreExist(id))
            {
                var genre = await _context.Genres.FindAsync(id);
                genre.Musics = await _context.MusicGenres.Where(a => a.GenreId == id).Include(a => a.Music).ToListAsync();
                var artist = await _context.MusicArtists.Include(a => a.Artist).ToListAsync();
                return genre;
            }
            return default;
        }

        public async Task<List<Genre>> GetGenres()
        {
            var genres = await _context.Genres.ToListAsync();
            return genres;
        }
    }
}
