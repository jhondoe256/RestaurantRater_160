using Microsoft.EntityFrameworkCore;
using RR_MVC.Data;
using RR_MVC.Data.Entities;
using RR_MVC.Models.RestaurantVM;
using RR_MVC.RestaurantRaterServices.Contracts;

namespace RR_MVC.RestaurantRaterServices
{
    public class RestaurantService : IRestaurantService
    {
        public readonly RestaurantDbContext _context;

        public RestaurantService(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateRestaurant(Restaurant_CreateVM model)
        {
            var entity = new Restaurant
            {
                Name = model.Name,
                Location = model.Location
            };

            await _context.Restaurants.AddAsync(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteRestaurant(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant is null) return false;

            _context.Restaurants.Remove(restaurant);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Restaurant_DetailVM> GetRestaurant(int id)
        {
            var restaurant = await _context.Restaurants.Include(r => r.Ratings).FirstOrDefaultAsync(x => x.Id == id);
            if (restaurant is null) return null;
            return new Restaurant_DetailVM
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Location = restaurant.Location,
                Score = restaurant.Score
            };
        }

        public async Task<List<Restaurant_ListItemVM>> GetRestaurants()
        {
            return await _context.Restaurants.Include(r => r.Ratings).Select(r => new Restaurant_ListItemVM
            {
                Id = r.Id,
                Name = r.Name,
                Score = r.Score
            }).ToListAsync();
        }

        public async Task<bool> UpdateRestaurant(Restaurant_EditVM model)
        {
            var restaurant = await _context.Restaurants.FindAsync(model.Id);
            if (restaurant is null) return false;

            restaurant.Name = model.Name;
            restaurant.Location = model.Location;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}