using AutoMapper;
using FireTruckFinder.Common.Mapping;
using FireTruckFinder.Data;
using FireTruckFinder.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace FireTruckFinder.Services.Models.Firepump
{
    public class FirepumpDetailsServiceModel : IMapFrom<FirePump>, IHaveCustomMapping
    {
        [Required]
        [MinLength(DataConstants.ModelTitleMinLength)]
        [MaxLength(DataConstants.ModelTitleMaxLength)]
        public string Model { get; set; }

        [Required]
        [Range(0, 100)]
        public double Efficiency { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Power { get; set; }

        public string SellerId { get; set; }

        public User Seller { get; set; }


        public void ConfigureMapping(Profile profile)
        {
            profile
                 .CreateMap<FirePump, FirepumpDetailsServiceModel>()
                 .ForMember(f => f.Seller, cfg => cfg.MapFrom(s => s.Seller.UserName));
        }
    }
}
