using RentVault.Api.Data;
using RentVaultAPI.Models;
using RentVaultAPI.Repositories.Interfaces;
using RentVaultAPI.Services.Interfaces;

namespace RentVaultAPI.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly RentVaultDbContext _context;
        public UserService(IUserRepository userRepository,RentVaultDbContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        public async Task AddUserAsync(string email, string password)
        {
            // 1️⃣ Business rule: email must be unique
            var existingUser = await _userRepository.GetByEmailAsync(email);
            if (existingUser != null)
                throw new Exception("User already exists");

            // 2️⃣ Create entity
            var user = new User
            {
                Email = email,
                HashPassword = HashPassword(password)
            };

            // 3️⃣ Prepare persistence
            await _userRepository.AddAsync(user);

            // 4️⃣ Commit (persistence boundary)
            await _context.SaveChangesAsync();
        }
        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }


    }

}
