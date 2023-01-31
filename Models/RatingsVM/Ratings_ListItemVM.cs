namespace RR_MVC.Models.RatingsVM
{
    public class Ratings_ListItemVM
    {
        public int Id { get; set; }
        public string RestaurantName { get; set; } = null!;
        public double FoodScore { get; set; }

        public double CleanlinessScore { get; set; }

        public double AtmosphereScore { get; set; }
    }
}