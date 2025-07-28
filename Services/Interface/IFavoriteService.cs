using WeatherApp.Data.Entities;

namespace Weartherapp.Services.Interface
{
    public interface IFavoriteService
    {
        Task<List<Favoritecity>> GetFavoritesByUserIdAsync(long userId);
        Task<bool> AddFavoriteAsync(long userId, string cityName);
        Task<bool> RemoveFavoriteAsync(long favoriteId);
    }
}
