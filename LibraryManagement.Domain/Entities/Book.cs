using System.ComponentModel.DataAnnotations;
using LibraryManagement.Domain.Entities.LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Enums;

namespace LibraryManagement.Domain.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(13)]
        public string ISBN { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Authors { get; set; } = string.Empty; // JSON string or comma-separated

        [Required]
        public string Genres { get; set; } = string.Empty; // JSON string or comma-separated

        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Pages { get; set; }
        public BookStatus Status { get; set; } = BookStatus.Available;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<Checkout> Checkouts { get; set; } = new List<Checkout>();
        public virtual ICollection<BookRating> Ratings { get; set; } = new List<BookRating>();
    }
}
