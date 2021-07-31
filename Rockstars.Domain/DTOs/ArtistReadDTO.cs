using System.Collections.Generic;

namespace Rockstars.Domain.DTOs
{
    public class ArtistReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SongReadDTO> Songs { get; set; }
    }
}
