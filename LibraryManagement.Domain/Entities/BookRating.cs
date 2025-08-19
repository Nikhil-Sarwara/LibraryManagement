using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace LibraryManagement.Domain.Entities
    {
        public class BookRating
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public int UserId { get; set; }

            [Required]
            public int BookId { get; set; }

            [Range(1, 5)]
            public int Rating { get; set; }

            [MaxLength(1000)]
            public string? Review { get; set; }

            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            // Navigation properties
            [ForeignKey("UserId")]
            public virtual User User { get; set; } = null!;

            [ForeignKey("BookId")]
            public virtual Book Book { get; set; } = null!;
        }
    }

}
