using System.ComponentModel.DataAnnotations;

namespace Rockstars.Domain.DTOs
{
    public class SongWriteDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Artist { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [MaxLength(100)]
        public string Shortname { get; set; }

        public int? Bpm { get; set; }
        
        [Required]
        public int Duration { get; set; }

        [Required]
        [MaxLength(100)]
        public string Genre { get; set; }

        [MaxLength(50)]
        public string SpotifyId { get; set; }

        [MaxLength(100)]
        public string Album { get; set; }
    }
}
