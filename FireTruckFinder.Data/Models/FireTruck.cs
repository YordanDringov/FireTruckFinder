namespace FireTruckFinder.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FireTruck
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.ModelTitleMinLength)]
        [MaxLength(DataConstants.ModelTitleMaxLength)]
        public string Make { get; set; }

        [Required]
        [MinLength(DataConstants.ModelTitleMinLength)]
        [MaxLength(DataConstants.ModelTitleMaxLength)]
        public string Model { get; set; }

        public Category Category { get; set; } 

        public int WatertankCapacity { get; set; }

        [Required]
        public DateTime ProduceDate { get; set; }

        [Required]
        [Range(DataConstants.MinPrice, DataConstants.MaxPrice)]
        public double Price { get; set; }

        public int PumpId { get; set; }

        public FirePump Pump { get; set; }

        public int SaleId { get; set; }

        public Sale Sale { get; set; }
    }
}
