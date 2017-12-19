namespace FireTruckFinder.Services.Models.FireTruck
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;

    public class FireTruckListingServiceModel : IMapFrom<FireTruck>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public double Price { get; set; }

        public User Seller { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile
                 .CreateMap<FireTruck, FireTruckListingServiceModel>()
                 .ForMember(f => f.Seller, cfg => cfg.MapFrom(s => s.Seller.UserName));
        }
    }
}