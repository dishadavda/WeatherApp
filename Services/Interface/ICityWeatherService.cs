using Weartherapp.Data.Model;

namespace Weartherapp.Services.Interface
{
    public interface ICityWeatherService
    {
        Task<List<WeatherForecast>> GetForecastForCityAsync(string cityName);
        Task<WeatherForecast> GetCurrentWeatherAsync(string cityName);
    }
}
