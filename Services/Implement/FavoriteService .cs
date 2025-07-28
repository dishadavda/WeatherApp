using Microsoft.EntityFrameworkCore;
using Weartherapp.Data;
using Weartherapp.Services.Interface;
using WeatherApp.Data.Entities;

namespace Weartherapp.Services.Implement
{
    public class FavoriteService : IFavoriteService
    {
        private readonly ApplicationDbContext _context;

        public FavoriteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Favoritecity>> GetFavoritesByUserIdAsync(long userId)
        {
            return await _context.favoritecities
                .Where(f => f.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> AddFavoriteAsync(long userId, string cityName)
        {
            var existing = await _context.favoritecities
                .Where(f => f.UserId == userId)
                .ToListAsync();

            if (existing.Count >= 5) return false;
            if (existing.Any(f => f.CityName == cityName)) return false;

            _context.favoritecities.Add(new Favoritecity { UserId = userId, CityName = cityName });
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveFavoriteAsync(long favoriteId)
        {
            var fav = await _context.favoritecities.FindAsync(favoriteId);
            if (fav == null) return false;

            _context.favoritecities.Remove(fav);
            await _context.SaveChangesAsync();
            return true;
        }
    }
    }
