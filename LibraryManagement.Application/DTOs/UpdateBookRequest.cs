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
        public class UpdateBookRequest
        {
            [MaxLength(500)]
            public string? Title { get; set; }

            public string? Authors { get; set; }
            public string? Genres { get; set; }

            [Range(1, 100)]
            public int? TotalCopies { get; set; }

            public DateTime? PublicationDate { get; set; }

            [Range(1, 10000)]
            public int? Pages { get; set; }
        }
    }

}
