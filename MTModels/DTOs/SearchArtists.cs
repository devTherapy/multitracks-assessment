using System.ComponentModel.DataAnnotations;

namespace MTModels.DTOs
{
    public class SearchArtists
    {
        [Required]
        public string Name { get; set; }
    }
}
