namespace RentVaultAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task AddUserAsync(string email, string password);
    }
}
