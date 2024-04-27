using Sleipnir.Dtos.Artist;
using Sleipnir.Dtos.Genre;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleipnir.Dtos.Music
{
    public class MusicDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public List<MusicArtistsDto> Artists { get; set; }
        public List<MusicGenresDto> Genres { get; set; }
        public string Adress { get; set; }
    }
}
