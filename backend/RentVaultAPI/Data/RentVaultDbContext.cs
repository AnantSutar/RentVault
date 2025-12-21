using Microsoft.EntityFrameworkCore;
using RentVaultAPI.Models;

namespace RentVault.Api.Data;

public class RentVaultDbContext : DbContext
{
    public RentVaultDbContext(DbContextOptions<RentVaultDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Document> Documents => Set<Document>();


}
