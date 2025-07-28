namespace Weartherapp.Data.Model
{
    public class ApplicationUser
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
    }
}
