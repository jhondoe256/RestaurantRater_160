using System.ComponentModel.DataAnnotations;

namespace RR_MVC.Models.RestaurantVM
{
    public class Restaurant_CreateVM
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Location { get; set; } = null!;
    }
}