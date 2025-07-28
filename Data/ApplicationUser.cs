using Microsoft.AspNetCore.Identity;

namespace Weartherapp.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? DisplayName { get; set; }
    }
}
