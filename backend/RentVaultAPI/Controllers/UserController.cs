using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentVaultAPI.DTOs.Requests;
using RentVaultAPI.Services.Interfaces;

namespace RentVaultAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserRequests request)
        {
            await _userService.AddUserAsync(request);
            return Ok();
        }
        // UPDATE (Partial update - MVP)
        [HttpPatch]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
        {
            await _userService.UpdateUserDetailsAsync(request);
            return NoContent();
        }
    }
}
