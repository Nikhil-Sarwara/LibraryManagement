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
        public class ReadingProgress
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public int UserId { get; set; }

            [Required]
            public int BookId { get; set; }

            public int CurrentPage { get; set; }
            public int TotalPages { get; set; }
            public TimeSpan ReadingTime { get; set; }
            public DateTime LastReadDate { get; set; } = DateTime.UtcNow;
            public bool IsCompleted { get; set; }

            // Navigation properties
            [ForeignKey("UserId")]
            public virtual User User { get; set; } = null!;

            [ForeignKey("BookId")]
            public virtual Book Book { get; set; } = null!;
        }
    }

}
