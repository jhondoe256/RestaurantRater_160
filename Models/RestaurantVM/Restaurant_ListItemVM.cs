using System.ComponentModel.DataAnnotations;

namespace RR_MVC.Models.RestaurantVM
{
    public class Restaurant_ListItemVM
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [Display(Name = "Average Score")]
        public double Score { get; set; }
    }
}