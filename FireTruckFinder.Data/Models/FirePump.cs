using System;
using System.Collections.Generic;
using System.Text;

namespace FireTruckFinder.Data.Models
{
    public class FirePump
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public double Efficiency { get; set; }

        public int Power { get; set; }
    }
}
