
using System.ComponentModel.DataAnnotations;

namespace LegislativeInfoSystem.DTOs
{
    public class LegislatorDTO
    {
        [Required(ErrorMessage = "First Name is required.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Hometown is required.")]
        public string? Hometown { get; set; }

    }
}
