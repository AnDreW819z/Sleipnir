namespace Sleipnir.Api.Models
{
    public class Playlist
    {
        public long Id { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsPublicPlaylist { get; set; }
        public List<PlaylistMusic>? Music { get; set; }
        public List<InvitedPerson>? InvitedPersons { get;set; }
    }
}
