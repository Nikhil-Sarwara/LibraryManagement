using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Application.DTOs
{
    public class UpdateUserRequest
    {
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }

        public List<string>? PreferredGenres { get; set; }
        public bool? IsActive { get; set; }
    }
}
