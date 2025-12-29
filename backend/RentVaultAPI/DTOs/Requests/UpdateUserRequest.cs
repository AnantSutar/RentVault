using System.ComponentModel.DataAnnotations;

namespace RentVaultAPI.DTOs.Requests
{
    public class UpdateUserRequest
    {

        [Required]
        public string CurrentEmail { get; set; } = null!;

        public string? NewEmail { get; set; }
        public string? NewPassword { get; set; }
    }
}
