using BasicCRM.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicCRM.Services
{
    public interface IAdminService
    {
        Task<IEnumerable<UpdateUserDto>> GetAllUsersAsync();
        Task<UpdateUserDto> GetUserByIdAsync(string userId);
        Task<bool> UpdateUserAsync(string userId, UpdateUserDto updateUserDto);
        Task<bool> DeleteUserAsync(string userId);
        Task<bool> AddRoleToUserAsync(string userId, string role);
        Task<bool> RemoveRoleFromUserAsync(string userId, string role);
        Task<IEnumerable<string>> GetAllRolesAsync();
        Task<bool> CreateRoleAsync(string roleName);
    }
}