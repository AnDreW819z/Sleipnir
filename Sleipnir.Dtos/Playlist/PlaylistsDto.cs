using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleipnir.Dtos.Playlist
{
    public class PlaylistsDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
    }
}
