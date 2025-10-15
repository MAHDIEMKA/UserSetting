namespace UserSetting.Models
{
    public class UserApp
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime CreateDateUser { get; set; } = DateTime.UtcNow;
        public bool IsRemoved { get; set; }

    }
}
