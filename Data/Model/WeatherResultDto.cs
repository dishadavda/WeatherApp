namespace WeatherApp.Data.Models
{
    public class WeatherResultDto
    {
        public string CityName { get; set; }  = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Temperature { get; set; }
        public string Icon { get; set; } = string.Empty;
    }
}
