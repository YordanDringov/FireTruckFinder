namespace FireTruckFinder.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        [MinLength(DataConstants.SellerNameMinLength)]
        [MaxLength(DataConstants.SellerNameMaxLength)]
        public string Name { get; set; }

        [Range(0,120)]
        public int Age { get; set; }

        public DateTime Birtdate { get; set; }

        public List<Sale> Sales { get; set; } = new List<Sale>();
    }
}
