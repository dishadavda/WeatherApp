namespace WeatherApp.Data.Models
{
    public class WeatherForecastDto
    {
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Temp { get; set; }
        public string Icon { get; set; } = string.Empty;
    }
}
