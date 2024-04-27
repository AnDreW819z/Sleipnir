namespace Sleipnir.Api.Models
{
    public class Genre
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public List<MusicGenre>? Musics { get; set; }
    }
}
