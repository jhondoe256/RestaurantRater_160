using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RR_MVC.Data;
using RR_MVC.Data.Entities;
using RR_MVC.Models.RatingsVM;
using RR_MVC.RestaurantRaterServices.Contracts;

namespace RR_MVC.RestaurantRaterServices
{
    public class RatingService : IRatingService
    {
        private readonly RestaurantDbContext _context;

        public RatingService(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddRating(Ratings_CreateVM model)
        {
            var entity = new Rating
            {
                RestaurantId = model.RestaurantId,
                AtmosphereScore = model.AtmosphereScore,
                CleanlinessScore = model.CleanlinessScore,
                FoodScore = model.FoodScore
            };

            await _context.Ratings.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Ratings_ListItemVM>> GetRatings()
        {
            return await _context.Ratings.Include(r => r.Restaurant).Select(r => new Ratings_ListItemVM
            {
                Id = r.Id,
                RestaurantName = r.Restaurant.Name,
                AtmosphereScore = r.AtmosphereScore,
                CleanlinessScore = r.CleanlinessScore,
                FoodScore = r.FoodScore
            }).ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> SelectListItemConversion()
        {
            return  await _context.Restaurants.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            }).ToListAsync();
        }
    }
}