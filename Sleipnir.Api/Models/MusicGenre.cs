using System.ComponentModel.DataAnnotations.Schema;

namespace Sleipnir.Api.Models
{
    public class MusicGenre
    {
        public long Id { get; set; }
        public long MusicId { get; set; }
        [ForeignKey("MusicId")]
        public Music Music { get; set; }
        public long GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
    }
}
