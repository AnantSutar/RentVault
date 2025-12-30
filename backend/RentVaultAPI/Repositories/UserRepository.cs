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

        public  Task AddAsync(User user)
        {
             _context.Users.AddAsync(user);
            return Task.CompletedTask;

            }

        public  Task<User?> GetByEmailAsync(string email)
        {
           return  _context.Users.FirstOrDefaultAsync(m => m.Email == email);

        }

        public Task<User?> GetByIdAsync(int id)
        {
            return _context.Users.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
