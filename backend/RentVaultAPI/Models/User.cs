namespace RentVaultAPI.Models
{
    public class User:BaseEntity
    {
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
