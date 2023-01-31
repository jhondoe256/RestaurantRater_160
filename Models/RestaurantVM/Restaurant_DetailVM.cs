namespace RR_MVC.Models.RestaurantVM
{
    public class Restaurant_DetailVM
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public double Score { get; set; }
    }
}