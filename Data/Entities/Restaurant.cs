using System.ComponentModel.DataAnnotations;

namespace RR_MVC.Data.Entities
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Location { get; set; } = null!;

        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();

        public double AverageFoodScore
        {
            get
            {
                return (Ratings.Count > 0) ? Math.Round((Ratings.Select(r => r.FoodScore).Sum() / Ratings.Count), 2) : 0;
            }
        }
        public double AverageCleanlinessScore
        {
            get
            {
                return (Ratings.Count > 0) ? Math.Round((Ratings.Select(r => r.CleanlinessScore).Sum() / Ratings.Count), 2) : 0;
            }
        }
        public double AverageAtmosphereScore => (Ratings.Count > 0) ? Math.Round(Ratings.Average(r => r.AtmosphereScore), 2) : 0;

        public double Score
        {
            get
            {
                return Math.Round((AverageAtmosphereScore + AverageCleanlinessScore + AverageFoodScore) / 3, 2);
            }
        }

    }
}