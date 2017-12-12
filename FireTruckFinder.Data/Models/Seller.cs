using System;
using System.Collections.Generic;

namespace FireTruckFinder.Data.Models
{
    public class Seller
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Birtdate { get; set; }

        public List<FireTruck> Firetrucks { get; set; }
    }
}
