
using global::LibraryManagement.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Domain.Entities
    {
        public class Checkout
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public int UserId { get; set; }

            [Required]
            public int BookId { get; set; }

            public DateTime CheckoutDate { get; set; } = DateTime.UtcNow;
            public DateTime DueDate { get; set; }
            public DateTime? ReturnDate { get; set; }
            public CheckoutStatus Status { get; set; } = CheckoutStatus.Active;
            public decimal? LateFee { get; set; }
            public string? QRToken { get; set; }
            public DateTime? QRTokenExpiry { get; set; }

            // Navigation properties
            [ForeignKey("UserId")]
            public virtual User User { get; set; } = null!;

            [ForeignKey("BookId")]
            public virtual Book Book { get; set; } = null!;
        }
    }