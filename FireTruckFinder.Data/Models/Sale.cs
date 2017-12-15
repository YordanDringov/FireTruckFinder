namespace FireTruckFinder.Data.Models
{
   public class Sale
    {
        public int Id { get; set; }

        public string SellerId { get; set; }

        public User Seller { get; set; }

        public int FireTruckId { get; set; }

        public FireTruck FireTruck { get; set; }

    }
}
