using LibraryManagement.Application.DTOs;

namespace LibraryManagement.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> GetByIdAsync(int id);
        Task<UserDto> CreateAsync(CreateUserRequest request);
        Task<UserDto> UpdateAsync(int id, UpdateUserRequest request);
        Task DeleteAsync(int id);
    }
}
