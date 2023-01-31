using RR_MVC.Models.RestaurantVM;

namespace RR_MVC.RestaurantRaterServices.Contracts
{
    public interface IRestaurantService
    {
        Task<bool> CreateRestaurant(Restaurant_CreateVM model);
        Task<List<Restaurant_ListItemVM>> GetRestaurants();
        Task<Restaurant_DetailVM> GetRestaurant(int id);
        Task<bool> UpdateRestaurant(Restaurant_EditVM model);
        Task<bool> DeleteRestaurant(int id);
    }
}