using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO
{
    public class AddWalkRequestDTO
    {
        [Required]
        [MinLength(10, ErrorMessage = "Name minimum 10 char")]
        [MaxLength(50, ErrorMessage = "Name maximum 50 char")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
