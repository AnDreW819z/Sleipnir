using Sleipnir.Dtos.Artist;
using Sleipnir.Dtos.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleipnir.Dtos.Music
{
    public class CreateMusicDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public string Adress { get; set; }
        public List<long> ArtistsIds { get; set; }
        public List<long> GenresIds { get; set; }
    }
}
