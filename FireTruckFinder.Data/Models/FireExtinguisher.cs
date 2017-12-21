using System.ComponentModel.DataAnnotations;

namespace FireTruckFinder.Data.Models
{
   public class FireExtinguisher
    {
        public int Id { get; set; }

        [Required]
        public FireExtinguisherType Type { get; set; }

        [Required]
        [Range(0,10000)]
        public double Price { get; set; }

        public string ImageUrl { get; set; }

        public string SellerId { get; set; }

        public User Seller { get; set; }

      



    }
}
