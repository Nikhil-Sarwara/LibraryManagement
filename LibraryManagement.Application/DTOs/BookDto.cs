namespace LibraryManagement.Application.DTOs
{
    namespace LibraryManagement.Application.DTOs
    {
        public class BookDto
        {
            public int Id { get; set; }
            public string ISBN { get; set; } = string.Empty;
            public string Title { get; set; } = string.Empty;
            public List<string> Authors { get; set; } = new();
            public List<string> Genres { get; set; } = new();
            public int TotalCopies { get; set; }
            public int AvailableCopies { get; set; }
            public bool IsAvailable => AvailableCopies > 0;
            public DateTime PublicationDate { get; set; }
            public int Pages { get; set; }
            public string Status { get; set; } = string.Empty;
        }
    }

}