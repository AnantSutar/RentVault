using System.ComponentModel.DataAnnotations;

namespace RentVaultAPI.DTOs.Requests
{
    public class AddUserRequests
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
