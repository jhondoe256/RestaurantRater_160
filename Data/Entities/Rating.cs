using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RR_MVC.Data.Entities
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        public int RestaurantId { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant Restaurant { get; set; } = null!;

        public double FoodScore { get; set; }

        public double CleanlinessScore { get; set; }

        public double AtmosphereScore { get; set; }
    }
}