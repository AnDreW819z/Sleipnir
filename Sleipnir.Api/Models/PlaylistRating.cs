using System.ComponentModel.DataAnnotations.Schema;

namespace Sleipnir.Api.Models
{
    public class PlaylistRating
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public long PlaylistId { get; set; }
        public double UserRating { get; set; }
        [ForeignKey ("PlaylistId")]
        public Playlist Playlist { get; set; }
    }
}
