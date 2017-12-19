namespace FireTruckFinder.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public DateTime Birtdate { get; set; }

        public List<FireTruck> FireTrucks { get; set; } = new List<FireTruck>();

        public List<FirePump> FirePumps { get; set; } = new List<FirePump>();

        public List<FireExtinguisher> FireExtinguishers { get; set; } = new List<FireExtinguisher>();
    }
}
