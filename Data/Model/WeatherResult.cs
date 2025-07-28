using System.Text.Json.Serialization;

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    // Temperature in Celsius.
    public int TemperatureC { get; set; }

    // Computed property for Temperature in Fahrenheit.
    public int TemperatureF { get; set; }

    // Summary of the weather (e.g., "Clouds", "Rain", "Clear").
    public string? Summary { get; set; }
}
public class OpenWeatherResponse
{
    [JsonPropertyName("list")]
    public List<ForecastItem> List { get; set; } = new();

    // You can add other properties from the root of the API response if needed, e.g.:
    // [JsonPropertyName("city")]
    // public City? City { get; set; }
    // [JsonPropertyName("cod")]
    // public string? Cod { get; set; }
    // [JsonPropertyName("message")]
    // public int Message { get; set; }
    // [JsonPropertyName("cnt")]
    // public int Cnt { get; set; }
}

public class ForecastItem
{
    [JsonPropertyName("dt_txt")]
    public string DtTxtRaw { get; set; } = "";  // get the raw string

    public DateTime DtTxt => DateTime.Parse(DtTxtRaw);  // safely convert

    [JsonPropertyName("main")]
    public ForecastMain Main { get; set; } = new();

    [JsonPropertyName("weather")]
    public List<ForecastWeather> Weather { get; set; } = new();

    // You can add other properties like "clouds", "wind", "visibility", "pop" if needed.
    // [JsonPropertyName("clouds")]
    // public ForecastClouds? Clouds { get; set; }
    // [JsonPropertyName("wind")]
    // public ForecastWind? Wind { get; set; }
}

public class ForecastMain
{
    // Maps to the "temp" field within the "main" object.
    [JsonPropertyName("temp")]
    public double Temp { get; set; }

    // Add other properties from "main" if you need them, e.g.:
    // [JsonPropertyName("feels_like")]
    // public double FeelsLike { get; set; }
    // [JsonPropertyName("humidity")]
    // public int Humidity { get; set; }
}

public class ForecastWeather
{
    // Maps to the "main" field within the "weather" array (e.g., "Clouds", "Rain").
    [JsonPropertyName("main")]
    public string Main { get; set; } = "";

    // You can add other properties like "description" or "icon" if needed.
    // [JsonPropertyName("description")]
    // public string? Description { get; set; }
    // [JsonPropertyName("icon")]
    // public string? Icon { get; set; }
}