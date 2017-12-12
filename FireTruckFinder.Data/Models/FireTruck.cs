namespace FireTruckFinder.Data.Models
{
    public class FireTruck
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public Category Category { get; set; }

        public FirePump Pump { get; set; }

        public int WatertankCapacity { get; set; }

        public decimal Price { get; set; }

        public int SellerId { get; set; }

        public Seller Seller { get; set; }


    }
}
