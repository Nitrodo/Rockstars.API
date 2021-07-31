using Rockstars.Domain.DTOs;
using System.Collections.Generic;

namespace Rockstars.Domain.Models
{
    public class ArtistWithSongsWrapper
    {
        public ArtistWriteDTO ArtistWriteDTO { get; set; }
        public IEnumerable<SongWriteDTO> SongWriteDTOs { get; set; }
    }
}