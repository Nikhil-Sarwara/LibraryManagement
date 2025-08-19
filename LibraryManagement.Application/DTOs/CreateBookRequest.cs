using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.DTOs
{
    using System.ComponentModel.DataAnnotations;

    namespace LibraryManagement.Application.DTOs
    {
        public class CreateBookRequest
        {
            [Required]
            [MaxLength(13)]
            public string ISBN { get; set; } = string.Empty;

            [Required]
            [MaxLength(500)]
            public string Title { get; set; } = string.Empty;

            [Required]
            public string Authors { get; set; } = string.Empty;

            [Required]
            public string Genres { get; set; } = string.Empty;

            [Range(1, 100)]
            public int TotalCopies { get; set; }

            public DateTime PublicationDate { get; set; }

            [Range(1, 10000)]
            public int Pages { get; set; }
        }
    }

}
