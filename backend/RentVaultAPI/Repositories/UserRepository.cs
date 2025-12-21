using RentVault.Api.Data;
using RentVaultAPI.Models;
using RentVaultAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RentVaultAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RentVaultDbContext _context;

        public UserRepository(RentVaultDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
           return await _context.Users.FirstOrDefaultAsync(m => m.Email == email);

        }
    }
}
