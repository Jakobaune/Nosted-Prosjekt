namespace NostedServicePro.Models.Account
{
    public class Users
    {

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public int? EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public int? PhoneNumberConfirmed { get; set; }
        public int? TwoFactorEnabled { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public int? LockoutEnabled { get; set; }
        public int? AccessFailedCount { get; set; }
    }
}
