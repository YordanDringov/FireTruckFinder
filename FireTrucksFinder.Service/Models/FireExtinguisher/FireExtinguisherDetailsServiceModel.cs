namespace FireTruckFinder.Services.Models.FireExtinguisher
{
    using FireTruckFinder.Common.Mapping;
    using FireTruckFinder.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;

    public class FireExtinguisherDetailsServiceModel : IMapFrom<FireExtinguisher>, IHaveCustomMapping
    {
        [Required]
        public FireExtinguisherType Type { get; set; }

        [Required]
        [Range(0, 10000)]
        public double Price { get; set; }

        public string ImageUrl { get; set; }

        public string SellerId { get; set; }

        public User Seller { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile
                .CreateMap<FireExtinguisher, FireExtinguisherDetailsServiceModel>()
                .ForMember(f => f.Seller, cfg => cfg.MapFrom(s => s.Seller.UserName));
        }
    }
}
