using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO
{
    public class AddRegionRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage ="Code minimum 3 char")]
        [MaxLength(3, ErrorMessage ="Code maximum 3 char")]
        public string Code { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage ="Length should be maximum 50 char")]
        public string Name { get; set; }
        public string? RegionaImageUrl { get; set; }
    }
}
