namespace FireTruckFinder.Services
{
    using Data.Models;
    using Models.FireTruck;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFireTruckService
    {
        Task<IEnumerable<FireTruckListingServiceModel>> AllAsync(int page = 1);

        Task<int> TotalAsync();

        Task<FireTruckDetailsServiceModel> ById(int id);

        Task CreateAsync(string make, string model, int watertankCapacity, DateTime produceDate, double price, string imageUrl, string sellerId);
    }
}
