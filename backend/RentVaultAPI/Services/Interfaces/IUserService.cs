using RentVaultAPI.DTOs.Requests;
using RentVaultAPI.DTOs.Responses;
using RentVaultAPI.Models;

namespace RentVaultAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task AddUserAsync(AddUserRequests request);

        Task UpdateUserDetailsAsync(UpdateUserRequest request);
        Task<UserDTO> GetUserByIdAsync(int userId);
        
    }
}
