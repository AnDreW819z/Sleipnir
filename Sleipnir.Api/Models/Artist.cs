namespace Sleipnir.Api.Models
{
    public class Artist
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? UserId { get; set; }
        public List<MusicArtist>? Musics { get; set; }
    }
}
