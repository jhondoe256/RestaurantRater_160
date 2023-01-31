using Microsoft.AspNetCore.Mvc.Rendering;
using RR_MVC.Models.RatingsVM;

namespace RR_MVC.RestaurantRaterServices.Contracts
{
    public interface IRatingService
    {
        Task<bool> AddRating(Ratings_CreateVM model);
        Task<List<Ratings_ListItemVM>> GetRatings();
        Task<IEnumerable<SelectListItem>> SelectListItemConversion();
    }
}