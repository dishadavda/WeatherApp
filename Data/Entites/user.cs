using System;
using System.Collections.Generic;

namespace WeatherApp.Data.Entities;

public partial class User
{
    public long UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public long RoleId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Favoritecity> favoritecities { get; set; } = new List<Favoritecity>();
}
