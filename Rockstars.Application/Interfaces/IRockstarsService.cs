using Rockstars.Domain.DTOs;
using System.Collections.Generic;

namespace Rockstars.Application.Interfaces
{
    public interface IRockstarsService
    {
        void FilterAndInsert(IEnumerable<ArtistWriteDTO> artists, IEnumerable<SongWriteDTO> songs);
        void FilterAndInsert(IEnumerable<SongWriteDTO> songs);
        ArtistReadDTO FindArtistByName(string name);
    }
}
