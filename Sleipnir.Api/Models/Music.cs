using System.ComponentModel.DataAnnotations.Schema;

namespace Sleipnir.Api.Models
{
    public class Music
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public List<MusicArtist> Artists { get; set; }
        public List<MusicGenre> Genres { get; set; }
        public string Adress { get; set; }
    }
}
