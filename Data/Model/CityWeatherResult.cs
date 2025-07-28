namespace Weartherapp.Data.Model
{
    public class CityWeatherResult
    {
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public List<WeatherForecast> Forecasts { get; set; } = new();
    }
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public float Temp { get; set; }
        public string Description { get; set; } = string.Empty;
    }
    public class OpenWeatherResponse
    {
        public List<WeatherListItem>? list { get; set; }
        public CityInfo? city { get; set; } 
    }

    public class WeatherListItem
    {
        public long dt { get; set; }
        public Main? main { get; set; }
        public List<Weather>? weather { get; set; }
    }

    public class Main
    {
        public float temp { get; set; }
    }

    public class Weather
    {
        public string description { get; set; } = string.Empty;
    }

    public class CityInfo
    {
        public string name { get; set; } = string.Empty;
        public string country { get; set; } = string.Empty;
    }
}
