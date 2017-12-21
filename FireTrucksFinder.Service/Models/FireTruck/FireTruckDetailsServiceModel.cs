namespace FireTruckFinder.Services.Models.FireTruck
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System;

    public class FireTruckDetailsServiceModel : IMapFrom<FireTruck>, IHaveCustomMapping
    {
       
        public string Make { get; set; }

        public string Model { get; set; }

        public int WatertankCapacity { get; set; }

        public DateTime ProduceDate { get; set; }

        public double Price { get; set; }

        public string Seller { get; set; }

        public string ImageUrl { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper.CreateMap<FireTruck, FireTruckDetailsServiceModel>()
                .ForMember(b => b.Seller, cfg => cfg
                    .MapFrom(b => b.Seller.UserName));
    }
}
