using Sleipnir.Api.Models;
using Sleipnir.Dtos.Auth;
using Sleipnir.Dtos.Genre;

namespace Sleipnir.Api.Interfaces
{
    public interface IGenreRepository
    {
        public Task<List<Genre>> GetGenres();
        public Task<Genre> GetGenre(long id);
        public Task<Genre> AddNewGenre(CreateGenreDto dto);
        public Task<Status> DeleteGenre(long id);
        public Task<bool> GenreExist(long id);
    }
}
