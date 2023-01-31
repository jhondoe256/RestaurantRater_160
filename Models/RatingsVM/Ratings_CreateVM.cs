using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RR_MVC.Models.RatingsVM
{
    public class Ratings_CreateVM
    {
        [Required]
        public int RestaurantId { get; set; }

        [Required]
        public double FoodScore { get; set; }

        [Required]
        public double CleanlinessScore { get; set; }

        [Required]
        public double AtmosphereScore { get; set; }

        public IEnumerable<SelectListItem> RestaurantOptions { get; set; } = new List<SelectListItem>();
    }
}