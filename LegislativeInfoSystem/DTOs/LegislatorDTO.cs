
using System.ComponentModel.DataAnnotations;

namespace LegislativeInfoSystem.DTOs
{
    public class LegislatorDTO
    {
        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[^<>{}\[\]]+$", ErrorMessage = "Invalid characters are not allowed.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [RegularExpression(@"^[^<>{}\[\]]+$", ErrorMessage = "Invalid characters are not allowed.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Hometown is required.")]
        [RegularExpression(@"^[^<>{}\[\]]+$", ErrorMessage = "Invalid characters are not allowed.")]
        public string? Hometown { get; set; }

    }
}
