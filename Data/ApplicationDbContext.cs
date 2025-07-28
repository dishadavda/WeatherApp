using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Weartherapp.Data.Entites;
using WeatherApp.Data.Entities;

namespace Weartherapp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public  DbSet<Favoritecity> favoritecities { get; set; }

        public  DbSet<Role> roles { get; set; }

        public  DbSet<User> users { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }

    }
}
