namespace WeatherApp.Data.Models
{
    public class WeatherResultDto
    {
        public string CityName { get; set; }
        public string Description { get; set; }
        public double Temperature { get; set; }
        public string Icon { get; set; }
    }
}
