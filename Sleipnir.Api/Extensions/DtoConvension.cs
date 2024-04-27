using Sleipnir.Api.Models;
using Sleipnir.Dtos.Artist;
using Sleipnir.Dtos.FollowMusic;
using Sleipnir.Dtos.Genre;
using Sleipnir.Dtos.Music;

namespace Sleipnir.Api.Extensions
{
    public static class DtoConvension
    {
        ///////// Artist /////////
        
        public static List<MusicArtistsDto> ConvertToDtos(this List<Artist> artists)
        {
            if (artists != null)
            {
                return (from artist in artists
                        select new MusicArtistsDto
                        {
                            ArtistId = artist.Id,
                            Name = artist.Name,
                            ImageUrl = artist.ImageUrl,
                        }).ToList();
            }
            return null;
        }
        public static ArtistDto ConverToDto(this Artist artist)
        {
            return new ArtistDto
            {
                Id = artist.Id,
                Name = artist.Name,
                Description = artist.Description,
                ImageUrl = artist.ImageUrl,
                Musics = artist.Musics.ConvertToDtos()
            };
        }

        ///////// Genre /////////
        public static List<GetGenresDto> ConvertToDto(this List<Genre> genres)
        {
            if (genres != null)
            {
                return (from genre in genres
                        select new GetGenresDto
                        {
                            Id = genre.Id,
                            Name = genre.Name,
                            ImageUrl= genre.ImageUrl,
                        }).ToList();
            }
            return null;
        }

        public static GenreDto ConverToDto(this Genre genre)
        {
            return new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name,
                ImageUrl = genre.ImageUrl,
                Musics = genre.Musics.ConvertToDtos()
            };
        }

        /////////////// Music //////////////////

        public static List<MusicDto> ConvertToDto(this List<Music> musics)
        {
            return (from music in musics
                    select new MusicDto
                    {
                        Id = music.Id,
                        Name = music.Name,
                        ImageUrl = music.ImageUrl,
                        Adress = music.Adress,
                        Artists = music.Artists.ConvertToDto(),
                    }).ToList();
        }

        public static MusicDto ConvertToDto(this Music music)
        {
            return new MusicDto
            {
                Id = music.Id,
                Name = music.Name,
                ImageUrl = music.ImageUrl,
                Adress = music.Adress,
                Artists = music.Artists.ConvertToDto(),
                Genres = music.Genres.ConvertToDto()
            };
        }

        /////////////// MusicArtists //////////////////

        public static List<MusicDto>? ConvertToDtos(this List<MusicArtist>? musics)
        {
            if(musics != null)
            {
                return (from music in musics
                        select new MusicDto
                        {
                            Id = music.MusicId,
                            Name = music.Music.Name,
                            Adress = music.Music.Adress,
                            Artists = music.Music.Artists.ConvertToDto(),
                            Genres = music.Music.Genres.ConvertToDto()

                        }).ToList();
            }
            return default;
        }
        public static List<MusicDto>? ConvertToDtos(this List<MusicGenre>? musics)
        {
            if (musics != null)
            {
                return (from music in musics
                        select new MusicDto
                        {
                            Id = music.MusicId,
                            Name = music.Music.Name,
                            Adress = music.Music.Adress,
                            Artists = music.Music.Artists.ConvertToDto(),
                            Genres = music.Music.Genres.ConvertToDto()

                        }).ToList();
            }
            return default;
        }

        public static List<MusicArtistsDto> ConvertToDto(this List<MusicArtist> artists)
        {
            if (artists != null)
            {
                return (from artist in artists
                        select new MusicArtistsDto
                        {
                            ArtistId = artist.ArtistId,
                            Name = artist.Artist.Name,
                            
                        }).ToList();
            }
            return null;
        }
        public static MusicArtistsDto ConvertToDto(this MusicArtist artist)
        {
            return new MusicArtistsDto
            {
                ArtistId = artist.ArtistId,
                Name = artist.Artist.Name,
            };
        }

        /////////////// MusicGenres //////////////////
        public static List<MusicGenresDto> ConvertToDto(this List<MusicGenre> genres)
        {
            if (genres != null)
            {
                return (from genre in genres
                        select new MusicGenresDto
                        {
                            GenreId = genre.GenreId,
                            Name = genre.Genre.Name,
                        }).ToList();
            }
            return null;
        }

        /////////////// FollowMusic //////////////////
        public static List<FollowMusicDto> ConvertToDtos(this List<FollowMusic> follows,
                                                           List<Music> musics)
        {
            return (from follow in follows
                    join music in musics
                    on follow.MusicId equals music.Id
                    select new FollowMusicDto
                    {
                        MusicId = follow.MusicId,
                        MusicName= music.Name,
                        Adress= music.Adress,
                        Artists = music.Artists.ConvertToDto()
                    }).ToList();
        }
    }
}
