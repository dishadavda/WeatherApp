using Microsoft.Extensions.Options;
using System.Text.Json;
using Weartherapp.Services.Interface;
using Weartherapp.Shared;

namespace Weartherapp.Services.Implement
{
    public class WeatherService : ICityWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        
        public WeatherService(HttpClient httpClient, IOptions<OpenWeatherSettings> settings)
        {
            _httpClient = httpClient;
            _apiKey = settings.Value.ApiKey;
            _apiKey = settings.Value.ApiKey ?? throw new Exception("Missing API key.");

        }

        public async Task<List<WeatherForecast>> GetForecastForCityAsync(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
                return new List<WeatherForecast>();

            var url = $"https://api.openweathermap.org/data/2.5/forecast?q={cityName}&appid={_apiKey}&units=metric";
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();

            var weatherData = await JsonSerializer.DeserializeAsync<OpenWeatherResponse>(stream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var forecasts = weatherData?.List?
                .GroupBy(x => DateOnly.FromDateTime(x.DtTxt.Date))
                .Select(g => new WeatherForecast
                {
                    Date = g.Key,
                    TemperatureC = (int)g.Average(x => x.Main.Temp),
                    Summary = g.First().Weather.First().Main
                })
                .Take(5)
                .ToList();

            return forecasts ?? new();
        }
        public async Task<WeatherForecast> GetCurrentWeatherAsync(string cityName)
        {

            var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={_apiKey}&units=metric");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to fetch current weather.");

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonDocument.Parse(json).RootElement;
            var unixTimestamp = data.GetProperty("dt").GetInt64(); // Get Unix time
            var dateTime = DateTimeOffset.FromUnixTimeSeconds(unixTimestamp).DateTime;
            var forecast = new WeatherForecast
            {
                Date = DateOnly.FromDateTime(dateTime),
                TemperatureC = (int)data.GetProperty("main").GetProperty("temp").GetDouble(),
                TemperatureF = (int)(data.GetProperty("main").GetProperty("temp").GetDouble() * 9 / 5 + 32),
                Summary = data.GetProperty("weather")[0].GetProperty("main").GetString()
            };

            return forecast;
        }
    }
}
