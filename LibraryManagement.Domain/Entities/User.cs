using System.ComponentModel.DataAnnotations;
using LibraryManagement.Domain.Entities.LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Enums;

namespace LibraryManagement.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        public UserRole Role { get; set; } = UserRole.Member;
        public string PreferredGenres { get; set; } = string.Empty; // JSON string
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual ICollection<Checkout> Checkouts { get; set; } = new List<Checkout>();
        public virtual ICollection<BookRating> Ratings { get; set; } = new List<BookRating>();
        public virtual ICollection<ReadingProgress> ReadingProgress { get; set; } = new List<ReadingProgress>();
    }
}
