using System;
using System.Collections.Generic;

namespace WeatherApp.Data.Entities;

public partial class Favoritecity
{
    public long Id { get; set; }

    public string CityName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public long UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
