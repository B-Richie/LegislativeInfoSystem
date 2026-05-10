
using System.ComponentModel.DataAnnotations;

namespace LegislativeInfoSystem.DTOs
{
    public class LegislationDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Legislation Title is required.")]
        [RegularExpression(@"^[^<>{}\[\]]+$", ErrorMessage = "Invalid characters are not allowed.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Legislation Text is required.")]
        [RegularExpression(@"^[^<>{}\[\]]+$", ErrorMessage = "Invalid characters are not allowed.")]
        public string? LegislationText { get; set; }

        public List<int> SponsorIds { get; set; } = [];

    }
}
