namespace WeatherApp.Data.Models
{
    public class WeatherForecastDto
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public double Temp { get; set; }
        public string Icon { get; set; }
    }
}
