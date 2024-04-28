using System.ComponentModel.DataAnnotations.Schema;

namespace Sleipnir.Api.Models
{
    public class PlaylistMusic
    {
        public long Id { get; set; }
        public long PlaylistId { get; set; }
        [ForeignKey("PlaylistId")]
        public Playlist Plalist { get; set; }
        public long MusicId { get; set; }
        [ForeignKey("MusicId")]
        public Music Music { get; set; }
    }
}
