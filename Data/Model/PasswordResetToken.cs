namespace Weartherapp.Data.Model
{
    public class PasswordResetToken
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public string Email {  get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }

        public virtual ApplicationUser User { get; set; } = default!;
    }
}
