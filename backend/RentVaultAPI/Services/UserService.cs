using Microsoft.EntityFrameworkCore;
using RentVault.Api.Data;
using RentVaultAPI.DTOs.Requests;
using RentVaultAPI.Models;
using RentVaultAPI.Repositories.Interfaces;
using RentVaultAPI.Services.Interfaces;

namespace RentVaultAPI.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly RentVaultDbContext _context;
        public UserService(IUserRepository userRepository, RentVaultDbContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        public async Task AddUserAsync(AddUserRequests request)
        {
            // 1️⃣ Business rule: email must be unique
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
                throw new Exception("User already exists");

            // 2️⃣ Create entity
            var user = new User
            {
                Email = request.Email,
                HashPassword = HashPassword(request.Password)
            };

            // 3️⃣ Prepare persistence
            await _userRepository.AddAsync(user);
            await _context.SaveChangesAsync();

        }
        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public async Task UpdateUserDetailsAsync(UpdateUserRequest request)
        {
            var updateUser = await _userRepository.GetByEmailAsync(request.CurrentEmail);
            if (updateUser == null)
                throw new Exception("User doesn't exists");

            if (!string.IsNullOrWhiteSpace(request.NewEmail))
                updateUser.Email = request.NewEmail;

            if (!string.IsNullOrWhiteSpace(request.NewPassword))
                updateUser.HashPassword = HashPassword(request.NewPassword);

            await _context.SaveChangesAsync();

        }
    }

}
