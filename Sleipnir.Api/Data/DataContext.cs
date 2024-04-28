using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sleipnir.Api.Models;

namespace Sleipnir.Api.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<MusicArtist> MusicArtists { get; set; }
        public DbSet<MusicGenre> MusicGenres { get; set;}
        public DbSet<TokenInfo> TokenInfo { get; set; }
        public DbSet<FollowMusic> FollowMusics { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistMusic > PlaylistsMusic { get; set; }
        public DbSet<PlaylistRating> PlaylistsRating { get; set; }
        public DbSet<InvitedPerson> InvitedPersons { get;set; }
    }
}
