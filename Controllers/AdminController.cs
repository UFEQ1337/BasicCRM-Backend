using BasicCRM.DTOs;
using BasicCRM.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _adminService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("users/{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            var user = await _adminService.GetUserByIdAsync(userId);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPut("users/{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, [FromBody] UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _adminService.UpdateUserAsync(userId, updateUserDto);
            if (!result) return NotFound();

            return NoContent();
        }

        [HttpDelete("users/{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var result = await _adminService.DeleteUserAsync(userId);
            if (!result) return NotFound();

            return NoContent();
        }

        [HttpPost("users/{userId}/roles")]
        public async Task<IActionResult> AddRoleToUser(string userId, [FromBody] string role)
        {
            var result = await _adminService.AddRoleToUserAsync(userId, role);
            if (!result) return BadRequest("Role not found or user not found.");

            return Ok();
        }

        [HttpDelete("users/{userId}/roles")]
        public async Task<IActionResult> RemoveRoleFromUser(string userId, [FromBody] string role)
        {
            var result = await _adminService.RemoveRoleFromUserAsync(userId, role);
            if (!result) return BadRequest("Role not found or user not found.");

            return Ok();
        }

        [HttpGet("roles")]
        public async Task<ActionResult<IEnumerable<string>>> GetAllRoles()
        {
            var roles = await _adminService.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpPost("roles")]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            var result = await _adminService.CreateRoleAsync(roleName);
            if (!result) return BadRequest("Role already exists.");

            return Ok();
        }
    }
}
