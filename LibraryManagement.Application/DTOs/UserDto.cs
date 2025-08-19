namespace LibraryManagement.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        public string Role { get; set; } = string.Empty;
        public List<string> PreferredGenres { get; set; } = new();
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
