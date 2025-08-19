using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Interfaces;
using LibraryManagement.Application.DTOs.LibraryManagement.Application.DTOs;

namespace LibraryManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get a user by ID
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User details</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound($"User with ID {id} not found.");

            return Ok(user);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="request">User creation request</param>
        /// <returns>Created user</returns>
        [HttpPost]
        [ProducesResponseType(typeof(UserDto), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = await _userService.CreateAsync(request);
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="request">User update request</param>
        /// <returns>Updated user</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, [FromBody] UpdateUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = await _userService.UpdateAsync(id, request);
                return Ok(user);
            }
            catch (ArgumentException)
            {
                return NotFound($"User with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound($"User with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all users (with pagination support)
        /// </summary>
        /// <param name="page">Page number (default: 1)</param>
        /// <param name="pageSize">Page size (default: 10)</param>
        /// <returns>Paginated list of users</returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<UserDto>), 200)]
        public async Task<ActionResult<PagedResult<UserDto>>> GetUsers([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            // You'll need to implement this in IUserService
            // For now, return a simple response
            return Ok(new PagedResult<UserDto>
            {
                Items = new List<UserDto>(),
                TotalCount = 0,
                Page = page,
                PageSize = pageSize
            });
        }

        /// <summary>
        /// Search users by email or name
        /// </summary>
        /// <param name="searchTerm">Search term</param>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Filtered list of users</returns>
        [HttpGet("search")]
        [ProducesResponseType(typeof(PagedResult<UserDto>), 200)]
        public async Task<ActionResult<PagedResult<UserDto>>> SearchUsers(
            [FromQuery] string? searchTerm,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            // You'll need to implement this in IUserService
            // For now, return a simple response
            return Ok(new PagedResult<UserDto>
            {
                Items = new List<UserDto>(),
                TotalCount = 0,
                Page = page,
                PageSize = pageSize
            });
        }

        /// <summary>
        /// Get user's reading history
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User's checkout history</returns>
        [HttpGet("{id}/history")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetUserHistory(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound($"User with ID {id} not found.");

            // Implementation for reading history would go here
            // You'll need to create a service method for this
            return Ok(new { message = "User history endpoint - to be implemented" });
        }

        /// <summary>
        /// Get user's current checkouts
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User's active checkouts</returns>
        [HttpGet("{id}/checkouts")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetUserCheckouts(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound($"User with ID {id} not found.");

            // Implementation for current checkouts would go here
            return Ok(new { message = "User checkouts endpoint - to be implemented" });
        }
    }
}
