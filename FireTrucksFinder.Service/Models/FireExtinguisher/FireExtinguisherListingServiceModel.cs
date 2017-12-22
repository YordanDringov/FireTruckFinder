
namespace FireTruckFinder.Services.Models.FireExtinguisher
{
    using AutoMapper;
    using FireTruckFinder.Common.Mapping;
    using FireTruckFinder.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class FireExtinguisherListingServiceModel : IMapFrom<FireExtinguisher>, IHaveCustomMapping
    {
        public int Id { get; set;}

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
                .CreateMap<FireExtinguisher, FireExtinguisherListingServiceModel>()
                .ForMember(f => f.Seller, cfg => cfg.MapFrom(s => s.Seller.UserName));
        }
    }
}
