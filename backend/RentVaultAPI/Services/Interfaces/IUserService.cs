using RentVaultAPI.DTOs.Requests;

namespace RentVaultAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task AddUserAsync(AddUserRequests request);

        Task UpdateUserDetailsAsync(UpdateUserRequest request);
        
    }
}
