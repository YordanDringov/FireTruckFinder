namespace FireTruckFinder.Data.Models
{
   public class Sale
    {
        public int Id { get; set; }

        public int SellerId { get; set; }

        public Seller Seller { get; set; }

        public int FireTruckId { get; set; }

        public FireTruck FireTruck { get; set; }

    }
}
