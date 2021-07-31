using Rockstars.Domain.DTOs;

namespace Rockstars.Domain.Models
{
    public class SongWithArtistIdWrapper
    {
        public SongWriteDTO SongWriteDTO { get; set; }
        public int ArtistId { get; set; }
    }
}
