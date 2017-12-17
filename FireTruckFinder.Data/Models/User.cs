namespace FireTruckFinder.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public DateTime Birtdate { get; set; }

        public List<Sale> Sales { get; set; } = new List<Sale>();
    }
}
