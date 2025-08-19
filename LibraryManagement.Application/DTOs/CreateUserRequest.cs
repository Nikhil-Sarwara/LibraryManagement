using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Application.DTOs
{
    public class CreateUserRequest
    {
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        public string Role { get; set; } = "Member";
        public List<string> PreferredGenres { get; set; } = new();
    }
}
