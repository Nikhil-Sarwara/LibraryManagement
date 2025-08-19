using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.DTOs
{
    namespace LibraryManagement.Application.DTOs
    {
        public class BookSearchRequest
        {
            public string? Title { get; set; }
            public string? Author { get; set; }
            public string? Genre { get; set; }
            public string? ISBN { get; set; }
            public bool? IsAvailable { get; set; }
            public int Page { get; set; } = 1;
            public int PageSize { get; set; } = 10;
        }
    }

}
