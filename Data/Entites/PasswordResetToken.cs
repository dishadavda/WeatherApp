namespace Weartherapp.Data.Entites
{
    public class PasswordResetToken
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }

       
    }
}
