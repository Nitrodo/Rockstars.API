using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rockstars.Domain.Entities
{
    [Index(nameof(Id), IsUnique = true)]
    public class Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Shortname { get; set; }

        public int Bpm { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Genre { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string SpotifyId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Album { get; set; }

        [Required]
        public int ArtistId { get; set; }
    }
}
