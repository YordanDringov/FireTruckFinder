namespace FireTruckFinder.Services
{
    using FireTruckFinder.Services.Models.Firepump;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFirepumpService
    {
        Task<IEnumerable<FirepumpListingServiceModel>> AllAsync(int page = 1);

        Task<int> TotalAsync();

        Task<FirepumpDetailsServiceModel> ById(int id);

        Task CreateAsync(string model, double efficiency, int power, double price, string imageUrl, string sellerId);
    }
}
