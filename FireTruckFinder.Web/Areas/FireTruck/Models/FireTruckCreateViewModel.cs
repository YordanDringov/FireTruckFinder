namespace FireTruckFinder.Web.Areas.FireTruck.Models
{
    using FireTruckFinder.Data;
    using FireTruckFinder.Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FireTruckCreateViewModel
    {
        [Required]
        [MinLength(DataConstants.ModelTitleMinLength)]
        [MaxLength(DataConstants.ModelTitleMaxLength)]
        public string Make { get; set; }

        [Required]
        [MinLength(DataConstants.ModelTitleMinLength)]
        [MaxLength(DataConstants.ModelTitleMaxLength)]
        public string Model { get; set; }

        public int WatertankCapacity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ProduceDate { get; set; }

        [Required]
        [MaxLength(2000)]
        [MinLength(10)]
        public string ImageUrl { get; set; }

        [Required]
        [Range(DataConstants.MinPrice, DataConstants.MaxPrice)]
        public double Price { get; set; }

        public string SellerId { get; set; }
    }
}
