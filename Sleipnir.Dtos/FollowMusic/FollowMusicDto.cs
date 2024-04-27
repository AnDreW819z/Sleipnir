using Sleipnir.Dtos.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleipnir.Dtos.FollowMusic
{
    public class FollowMusicDto
    {
        public long MusicId { get; set; }
        public string MusicName {get; set;}
        public string Adress { get; set; }
        public List<MusicArtistsDto> Artists { get; set; }
        
    }
}
