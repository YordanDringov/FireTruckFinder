namespace FireTruckFinder.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class FirePump
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.ModelTitleMinLength)]
        [MaxLength(DataConstants.ModelTitleMaxLength)]
        public string Model { get; set; }

        [Required]
        [Range(0,100)]
        public double Efficiency { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Power { get; set; }

        public List<FireTruck> Firetrucks { get; set; } = new List<FireTruck>();
    }
}
