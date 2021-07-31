using System.ComponentModel.DataAnnotations;

namespace Rockstars.Domain.DTOs
{
    public class ArtistWriteDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
