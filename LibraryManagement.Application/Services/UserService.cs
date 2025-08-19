using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;

namespace LibraryManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateAsync(CreateUserRequest request)
        {
            var user = _mapper.Map<User>(request);
            await _userRepository.AddAsync(user);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateAsync(int id, UpdateUserRequest request)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new ArgumentException("User not found");

            _mapper.Map(request, user);
            user.UpdatedAt = DateTime.UtcNow;
            await _userRepository.UpdateAsync(user);
            return _mapper.Map<UserDto>(user);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new ArgumentException("User not found");

            await _userRepository.DeleteAsync(user);
        }
    }
}
