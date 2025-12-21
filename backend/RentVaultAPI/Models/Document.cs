namespace RentVaultAPI.Models
{
    public class Document:BaseEntity
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
