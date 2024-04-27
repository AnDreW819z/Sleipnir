using System.ComponentModel.DataAnnotations.Schema;

namespace Sleipnir.Api.Models
{
    public class MusicArtist
    {
        public long Id { get; set; }
        public long MusicId { get; set; }
        [ForeignKey("MusicId")]
        public Music Music { get; set; }
        public long ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }
    }
}
