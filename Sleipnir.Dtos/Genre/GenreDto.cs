using Sleipnir.Dtos.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleipnir.Dtos.Genre
{
    public class GenreDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public List<MusicDto>? Musics { get; set; }
    }
}
