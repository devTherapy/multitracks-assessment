using MTModels.Entities;
using System.ComponentModel.DataAnnotations;

namespace MTModels.DTOs
{
    public class CreateArtist
    {
        [Required()]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characers")]
        public string Title { get; set; }
        [Required]
        public string Bography { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "ImageURL cannot exceed 500 characers")]
        public string ImageURL { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "HeroURL cannot exceed 500 characers")]
        public string HeroURL { get; set; }
    }

}
