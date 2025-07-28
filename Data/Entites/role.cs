using System;
using System.Collections.Generic;

namespace WeatherApp.Data.Entities;

public partial class Role
{
    public long Id { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<User> users { get; set; } = new List<User>();
}
